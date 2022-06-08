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
RpcManagedClient mqtt = new(config);
mqtt.LogAsync += Log;
PrintLine($"# Starting station {stationId} ", ConsoleColor.Yellow);

// TOPICS
// control the serial
string gcode = config.SerialGcodeTopic.Replace("{StationId}", stationId);
string serialOpen = config.SerialOpenTopic.Replace("{StationId}", stationId);
string serialClose = config.SerialCloseTopic.Replace("{StationId}", stationId);
string serialReset = config.SerialResetTopic.Replace("{StationId}", stationId);
// control the camera
string cameraStreamCapture = config.CameraStreamCaptureTopic.Replace("{StationId}", stationId);
string cameraSimpleCapture = config.CameraSimpleCaptureTopic.Replace("{StationId}", stationId);
string cameraStream = config.CameraStreamStopic.Replace("{StationId}", stationId);
string cameraStop = config.CameraStopTopic.Replace("{StationId}", stationId);
// set camera resolution
string cameraVideoSolutionFullHD = config.CameraVideoSolutionTopicFullHD.Replace("{StationId}", stationId);
string cameraVideoSolutionHD = config.CameraVideoSolutionTopicHD.Replace("{StationId}", stationId);
string cameraVideoSolutionSD = config.CameraVideoSolutionTopicSD.Replace("{StationId}", stationId);
string cameraImageSolution = config.CameraImageSolutionTopic.Replace("{StationId}", stationId);
// control the bash shell
string bashCommand = config.BashCommandTopic.Replace("{StationId}", stationId);
// rpc topics
string rpcStreamStatus = config.RpcStreamStatusTopic.Replace("{StationId}", stationId);
string rpcStatus = config.RpcRpiStatusTopic.Replace("{StationId}", stationId);

// ASSIGN THE HANDLER METHODS
// control the serial port
RpiSerial serial = new(config, Log);
mqtt.Handlers[gcode] = msg => serial.WriteGcodeAsync(msg);
mqtt.Handlers[serialOpen] = msg => serial.OpenPortAsync();
mqtt.Handlers[serialClose] = msg => serial.ClosePortAsync();
mqtt.Handlers[serialReset] = msg => serial.ResetPortAsync();
// control the camera
RpiCamera camera = new(config, mqtt, Log);
mqtt.Handlers[cameraStreamCapture] = msg => camera.CaptureAsync(true);
mqtt.Handlers[cameraSimpleCapture] = msg => camera.CaptureAsync(false);
mqtt.Handlers[cameraStream] = msg => camera.StartStreamingAsync();
mqtt.Handlers[cameraStop] = msg => camera.StopStreamingAsync();
// set camera resolution
mqtt.Handlers[cameraVideoSolutionFullHD] = msg => camera.SetVideoResolution(new Resolution() { Width = 1920, Height = 1080 });
mqtt.Handlers[cameraVideoSolutionHD] = msg => camera.SetVideoResolution(new Resolution() { Width = 1280, Height = 720 });
mqtt.Handlers[cameraVideoSolutionSD] = msg => camera.SetVideoResolution(new Resolution() { Width = 640, Height = 480 });
// set image resolution
mqtt.Handlers[cameraImageSolution] = msg => camera.SetImageResolution(msg);
// RPC 
mqtt.RpcHandlers[rpcStreamStatus] = msg => camera.GetStreamingStatus();
mqtt.RpcHandlers[rpcStatus] = msg => "true".GetBytes();
// control the RPi
RpiBash bash = new(config);
mqtt.Handlers[bashCommand] = msg => bash.RunBashCommandAsync(msg);

// start the mqtt client
await mqtt.StartAsyncWithRpc();
// pause the thread forever
Thread.Sleep(-1);

#region HELPER METHODS
// say goodbye when exit
Console.CancelKeyPress += (s, e) => {
    Console.WriteLine("Goodbye!");
};

// log events back to LogHub / desktop client
async Task Log(string message, LogType type = LogType.Information) {
    var msg = type switch {
        LogType.Information => $"[OK] {message}",
        LogType.Error => $"[ER] {message}",
        LogType.System => $"[SY] {message}",
        LogType.Command => $"[CM] {message}",
        _ => message
    };
    await mqtt.PublishStringAsync(logTopic, msg);
}

#endregion