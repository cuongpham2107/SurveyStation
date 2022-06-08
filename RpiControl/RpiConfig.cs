using Common;

/// <summary>
/// Class for all configurations, saved in json file
/// </summary>
public class RpiConfig : MqttConfig {
    public RpiConfig() : base() { }

    public string StationId { get; set; } = Guid.NewGuid().ToString();

    //mqtt topics
    public string AllCommandTopic { get; set; } = "{StationId}/#";
    public string SerialGcodeTopic { get; set; } = "{StationId}/gcode";
    public string SerialOpenTopic { get; set; } = "{StationId}/serial/open";
    public string SerialCloseTopic { get; set; } = "{StationId}/serial/close";
    public string SerialResetTopic { get; set; } = "{StationId}/serial/reset";
    
    public string CameraStreamCaptureTopic { get; set; } = "{StationId}/camera/streamcapture";
    public string CameraSimpleCaptureTopic { get; set; } = "{StationId}/camera/simplecapture";
    public string CameraStreamStopic { get; set; } = "{StationId}/camera/stream";
    public string CameraStopTopic { get; set; } = "{StationId}/camera/stop";
    public string CameraVideoSolutionTopic { get; set; } = "{StationId}/solution/video";
    public string CameraVideoSolutionTopicFullHD { get; set; } = "{StationId}/solution/video/fullhd"; // 1920x1080
    public string CameraVideoSolutionTopicHD { get; set; } = "{StationId}/solution/video/hd"; // 1280x720
    public string CameraVideoSolutionTopicSD { get; set; } = "{StationId}/solution/video/sd"; // 640x480
    public string CameraImageSolutionTopic { get; set; } = "{StationId}/solution/image";

    public string BashCommandTopic { get; set; } = "{StationId}/bash";

    public string RpcStreamStatusTopic { get; set; } = "{StationId}.streamstatus";
    public string RpcRpiStatusTopic { get; set; } = "{StationId}.status";

    public string ImageTopic { get; set; } = "img/{StationId}";
    public string LogTopic { get; set; } = "log/{StationId}";

    // serial port
    public string PortName { get; set; } = "/dev/ttyUSB0";
    public int BaudRate { get; set; } = 115200;

    // bash process
    public bool RedirectStandardOutput { get; set; } = false;
    public bool RedirectStandardError { get; set; } = false;
    public bool UseShellExecute { get; set; } = false;

    // camera
    public string RaspividFfmpeg { get; set; } = "raspivid -t 0 -w {Width} -h {Height} -fps 25 -g 75 -fl -o - | ffmpeg -i pipe:0 -c:v copy -f flv -f flv rtmp://app.kennatech.vn:1935/live/{StationId}";
    public string KillRaspivid { get; set; } = "sudo pkill -f raspivid";
    public string KillFfmpeg { get; set; } = "sudo pkill -f ffmpeg";
    public string Raspistill { get; set; } = "raspistill -w {Width} -h {Height}  -o {FileName} -t 1000";
}