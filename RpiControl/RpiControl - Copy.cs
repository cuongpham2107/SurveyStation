using Common;
using MQTTnet.Client;
using static Common.Helper;
using System.Text;
using MQTTnet;

// initiate parameters
RpiConfig config = ConfigManager<RpiConfig>.Instance.Config;
string stationId = config.StationId;
string commandTopic = config.AllCommandTopic.Replace("{StationId}", stationId);
string logTopic = config.LogTopic.Replace("{StationId}", stationId);
Dictionary<string, Func<MqttApplicationMessage, Task>> Handlers = new();
ManagedClient mqtt = new(config);

PrintLine($"# Starting station {stationId} ", ConsoleColor.Yellow);

// topics
string gcode = config.SerialGcodeTopic.Replace("{StationId}", stationId);
string serialOpen = config.SerialOpenTopic.Replace("{StationId}", stationId);
string serialClose = config.SerialCloseTopic.Replace("{StationId}", stationId);
string serialReset = config.SerialResetTopic.Replace("{StationId}", stationId);
string cameraStreamCapture = config.CameraStreamCaptureTopic.Replace("{StationId}", stationId);
string cameraSimpleCapture = config.CameraSimpleCaptureTopic.Replace("{StationId}", stationId);
string cameraStream = config.CameraStreamStopic.Replace("{StationId}", stationId);
string cameraStop = config.CameraStopTopic.Replace("{StationId}", stationId);
string cameraVideoSolution = config.CameraVideoSolutionTopic.Replace("{StationId}", stationId);
string cameraVideoSolutionFullHD = config.CameraVideoSolutionTopicFullHD.Replace("{StationId}", stationId);
string cameraVideoSolutionHD = config.CameraVideoSolutionTopicHD.Replace("{StationId}", stationId);
string cameraVideoSolutionSD = config.CameraVideoSolutionTopicSD.Replace("{StationId}", stationId);

string cameraImageSolution = config.CameraImageSolutionTopic.Replace("{StationId}", stationId);
string bashCommand = config.BashCommandTopic.Replace("{StationId}", stationId);

// control the serial port
RpiSerial serial = new(config, Log);
Handlers[gcode] = msg => serial.WriteGcodeAsync(msg);
Handlers[serialOpen] = msg => serial.OpenPortAsync();
Handlers[serialClose] = msg => serial.ClosePortAsync();
Handlers[serialReset] = msg => serial.ResetPortAsync();

// control the camera
RpiCamera camera = new(config, mqtt, Log);
Handlers[cameraStreamCapture] = msg => camera.CaptureAsync(true);
Handlers[cameraSimpleCapture] = msg => camera.CaptureAsync(false);
Handlers[cameraStream] = msg => camera.StartStreamingAsync();
Handlers[cameraStop] = msg => camera.StopStreamingAsync();

Handlers[cameraVideoSolution] = msg => camera.SetResolution(msg, ComponentType.Video);
Handlers[cameraVideoSolutionFullHD] = msg => camera.SetVideoResolution(ComponentType.Video, new Resolution() { Width = 1920, Height = 1080 });
Handlers[cameraVideoSolutionHD] = msg => camera.SetVideoResolution(ComponentType.Video, new Resolution() { Width = 1280, Height = 720 });
Handlers[cameraVideoSolutionSD] = msg => camera.SetVideoResolution(ComponentType.Video, new Resolution() { Width = 640, Height = 480 });

Handlers[cameraImageSolution] = msg => camera.SetResolution(msg, ComponentType.Image);

// control the RPi
RpiBash bash = new(config);
Handlers[bashCommand] = msg => bash.RunBashCommandAsync(msg);

// run when client is connected to server
mqtt.Client.ConnectedAsync += Client_ConnectedAsync;
// run when client is disconnected from server
mqtt.Client.DisconnectedAsync += Client_DisconnectedAsync;
// run when client receives command from server
mqtt.Client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;

// start client and subscribe to control topic
await mqtt.StartAsync();
await mqtt.SubscribeAsync(commandTopic);

// pause the thread forever
Thread.Sleep(-1);

#region HELPER METHODS

AppDomain.CurrentDomain.UnhandledException += async (s, e) => {
    await Log(e.ExceptionObject.ToString(), LogType.Error);
};

Console.CancelKeyPress += (s, e) => {
    Console.WriteLine("Goodbye!");
};

// run when client is disconnected from server
async Task Client_DisconnectedAsync(EventArgs arg) {
    await Task.Run(() => PrintLine("# Disconnected from server", ConsoleColor.Red));
}

// run when client connected to server
async Task Client_ConnectedAsync(EventArgs arg) {
    PrintLine("# Connected to server. Listening to command ...", ConsoleColor.Yellow);
    await Log($"Connected to server. Listening to command ...", LogType.System);
}

// run when client receives command from server
async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg) {
    string topic = arg.ApplicationMessage.Topic;
    byte[] payload = arg.ApplicationMessage.Payload;
    var command = topic.Remove(0, 36);

    var type = arg.ApplicationMessage.ContentType;
    if (type == "string" || type == "json") {
        string payloadString = Encoding.UTF8.GetString(payload);
        await Log($"{command} {payloadString}", LogType.Command);
    } else {
        await Log(command, LogType.Command);
    }

    try {
        await Handlers[topic].Invoke(arg.ApplicationMessage);
    } catch (Exception e) {
        // catch any exception so that program does not crash
        await Log(e.Message, LogType.Error);
    }
}

// log events back to LogHub
async Task Log(string message, LogType type = LogType.Infor) {
    var msg = type switch {
        LogType.Infor => $"[OK] {message}",
        LogType.Error => $"[ER] {message}",
        LogType.System => $"[SY] {message}",
        LogType.Command => $"[CM] {message}",
        _ => message
    };
    await mqtt.PublishStringAsync(logTopic, msg);
}

#endregion