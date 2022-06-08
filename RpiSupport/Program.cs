using Common;
using MQTTnet.Client;
using static Common.Helper;
using System.Text;
using MQTTnet;
using System.Diagnostics;

RpiSupport config = ConfigManager<RpiSupport>.Instance.Config;

string logTopic = config.LogTopic.Replace("{StationId}", config.StationId);
string bashCommand = config.BashCommandTopic.Replace("{StationId}",config.StationId);
Dictionary<string, Func<MqttApplicationMessage, Task>> Handlers = new();
ManagedClient mqtt = new(config);


Handlers[bashCommand] = msg => RunBashCommandAsync(msg);

mqtt.Client.ConnectedAsync += Client_ConnectedAsync;
mqtt.Client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;

async Task Client_ConnectedAsync(EventArgs arg) {    
    await Log($"Connected to server. Listening to command ...");
}

async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg) {
    string topic = arg.ApplicationMessage.Topic;
    byte[] payload = arg.ApplicationMessage.Payload;
    var command = topic.Remove(0, 36);

    var type = arg.ApplicationMessage.ContentType;
    if (type == "string" || type == "json") {
        string payloadString = Encoding.UTF8.GetString(payload);
        await Log($"> {command} {payloadString}");
    } else {
        await Log($"> {command}");
    }

    try {
        await Handlers[command].Invoke(arg.ApplicationMessage);
    } catch (Exception e) {
        // catch any exception so that program does not crash
        await Log(e.Message);
    }
}

async Task RunBashCommandAsync(MqttApplicationMessage msg) {
    string arguments = Encoding.UTF8.GetString(msg.Payload);
    ProcessStartInfo psi = new() {
        FileName = "bash",
        Arguments = "-c \"" + arguments + "\"",
        RedirectStandardOutput = false,
        RedirectStandardError = false,
        UseShellExecute = false
    };
    Process process = new() {
        StartInfo = psi
    };
    await Task.Run(() => process.Start());
}

async Task Log(string message) {
    await mqtt.PublishStringAsync(logTopic, message);
}

Console.CancelKeyPress += (s, e) => {
    Console.WriteLine("Goodbye!");
};

AppDomain.CurrentDomain.UnhandledException += async (s, e) => {
    await mqtt.PublishStringAsync(logTopic, e.ExceptionObject.ToString());
};

public class RpiSupport : MqttConfig {
    public string StationId { get; set; } = Guid.NewGuid().ToString();
    public string LogTopic { get; set; } = "log/{StationId}";
    public string BashCommandTopic { get; set; } = "{StationId}/bash";
}
