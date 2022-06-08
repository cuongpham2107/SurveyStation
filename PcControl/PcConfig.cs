using Common;

namespace PcControl {
    /// <summary>
    /// Class for station information
    /// </summary>
    public class Station {
        public string Name { get; set; } = "Station N01";
        public string Description { get; set; } = "A new station";
        public string StationId { get; set; } = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Class for list of stations, saved in json file
    /// </summary>
    public class CustomerStations {
        public Station[] Stations { get; set; } = new[] { new Station() };
    }

    /// <summary>
    /// Class for all configurations, saved in json file
    /// </summary>
    public class PcConfig : MqttConfig {
        public string ImageFolder { get; set; } = @"C:\Images";
        public string LogFile { get; set; } = "log.txt";

        // stream
        public string StreamUrl { get; set; } = "rtsp://app.kennatech.vn:1935/live/{0}";

        // placeholders
        public string[] Ph { get; set; } = new[] { "{0}", "{1}", "{2}", "{3}", "{4}" };

        // ranges
        public int HMin { get; set; } = -25; // giới hạn quay mặt ngang y
        public int HMax { get; set; } = 25; // 180 độ

        public int VMin { get; set; } = 1; // giới hạn quay mặt đứng x
        public int VMax { get; set; } = 50; // 360 độ

        public int ZMin { get; set; } = -15; // giới hạn dịch chuyển lens -15 độ
        public int ZMax { get; set; } = 15; // + 15 độ

        public int LMin { get; set; } = -15; // giới hạn chỉnh focus -15 độ
        public int LMax { get; set; } = 15; // + 15 độ

        // control steps
        public int HStep { get; set; } = 5; // bước dịch quay mặt ngang y
        public int VStep { get; set; } = 5; // bước dịch quay mặt đứng x
        public int ZStep { get; set; } = 1; // bước dịch chỉnh lens
        public int LStep { get; set; } = 1; // bước dịch chỉnh focus

        // gcodes
        public string HCode { get; set; } = "G01 Y{0} f200"; // xoay mặt ngang y
        public string VCode { get; set; } = "G01 X{0} f200"; // xoay mặt đứng x
        public string ZCode { get; set; } = "G01 B{0} f200"; // dịch chuyển lens
        public string LCode { get; set; } = "G01 A{0} f200"; // chỉnh focus

        // topics

        public string CameraStreamTopic { get; set; } = "{0}/camera/stream";
        public string CameraStopTopic { get; set; } = "{0}/camera/stop";
        public string CameraStreamCaptureTopic { get; set; } = "{0}/camera/streamcapture";
        public string CameraSimpleCaptureTopic { get; set; } = "{0}/camera/simplecapture";
        public string CameraVideoSolutionTopic { get; set; } = "{0}/solution/video";
        public string CameraVideoSolutionTopicFullHD { get; set; } = "{0}/solution/video/fullhd"; // 1920x1080
        public string CameraVideoSolutionTopicHD { get; set; } = "{0}/solution/video/hd"; // 1280x720
        public string CameraVideoSolutionTopicSD { get; set; } = "{0}/solution/video/sd"; // 640x480

        public string CameraImageSolutionTopic { get; set; } = "{0}/solution/image";

        public string SerialGcodeTopic { get; set; } = "{0}/gcode";
        public string SerialOpenTopic { get; set; } = "{0}/serial/open";
        public string SerialResetTopic { get; set; } = "{0}/serial/reset";
        public string SerialCloseTopic { get; set; } = "{0}/serial/close";
        public string LogTopic { get; set; } = "log/{0}";
        public string ImageTopic { get; set; } = "img/{0}";

        public string RpcStreamStatusTopic { get; set; } = "{0}.streamstatus";
        public string RpcRpiStatusTopic { get; set; } = "{0}.status";
    }


}