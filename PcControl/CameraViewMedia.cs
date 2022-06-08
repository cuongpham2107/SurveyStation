using Common;
using LibVLCSharp.Shared;
using System.Diagnostics;
using System.Text;

namespace PcControl {
    public class CameraViewMedia {
        private readonly PcConfig cfg = ConfigManager<PcConfig>.Instance.Config;

        private readonly LibVLC vlc;
        private readonly MediaPlayer player;
        private readonly Media media;
        private readonly string streamUrl;
        private readonly RpcManagedClient mqtt;
        private readonly string stationId;

        private readonly string streamTopic, stopTopic, captureTopic, imgTopic, fullHDStreamingTopic, hdStreamingTopic, sdStreamingTopic;

        public VideoResolution[] Resolutions = new[] {
            new VideoResolution { Name = "fullhd", Description = "Full HD (1920x1080)" },
            new VideoResolution { Name = "hd", Description = "HD (1280x720)" },
            new VideoResolution { Name = "sd", Description = "SD (640x480)" } };

        private VideoResolution currentResolution;
        public VideoResolution CurrentResolution {
            get => currentResolution; set {
                //if (value == currentResolution) return;
                currentResolution = value;

                if (currentResolution.Name == "fullhd")
                    _ = mqtt.PublishNoPayloadAsync(fullHDStreamingTopic);
                if (currentResolution.Name == "hd")
                    _ = mqtt.PublishNoPayloadAsync(hdStreamingTopic);
                if (currentResolution.Name == "sd")
                    _ = mqtt.PublishNoPayloadAsync(sdStreamingTopic);

                //_ = StopStreamingAsync().ContinueWith(t => Task.Delay(1000)).ContinueWith(t => StartStreamingAsync()).ContinueWith(t => Task.Delay(2000).ContinueWith(t => PlayAsync()));

            }
        }

        public CameraViewMedia(string stationId, RpcManagedClient mqtt) {
            this.stationId = stationId;
            vlc = new();
            player = new(vlc);
            streamUrl = cfg.StreamUrl.Replace(cfg.Ph[0], stationId);
            media = new(vlc, streamUrl, FromType.FromLocation);
            this.mqtt = mqtt;

            streamTopic = cfg.CameraStreamTopic.Replace(cfg.Ph[0], stationId);
            stopTopic = cfg.CameraStopTopic.Replace(cfg.Ph[0], stationId);
            captureTopic = cfg.CameraSimpleCaptureTopic.Replace(cfg.Ph[0], stationId);
            imgTopic = cfg.ImageTopic.Replace(cfg.Ph[0], stationId);
            fullHDStreamingTopic = cfg.CameraVideoSolutionTopicFullHD.Replace(cfg.Ph[0], stationId);
            hdStreamingTopic = cfg.CameraVideoSolutionTopicHD.Replace(cfg.Ph[0], stationId);
            sdStreamingTopic = cfg.CameraVideoSolutionTopicSD.Replace(cfg.Ph[0], stationId);


            mqtt.Client.ApplicationMessageReceivedAsync += ReceiveImageHandling;
            CurrentResolution = Resolutions[1];
        }

        private async Task ReceiveImageHandling(MQTTnet.Client.MqttApplicationMessageReceivedEventArgs arg) {
            if (arg.ApplicationMessage.Topic != imgTopic) return;
            var fileName = Encoding.UTF8.GetString(arg.ApplicationMessage.CorrelationData);
            var fullFileName = Path.Combine(cfg.ImageFolder, fileName);
            await File.WriteAllBytesAsync(fullFileName, arg.ApplicationMessage.Payload)
                .ContinueWith((t) => MessageBox.Show("Image downloaded"))
                .ContinueWith((t) => {
                    ProcessStartInfo psi = new(fullFileName) {
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                });
        }

        public string StreamUrl => streamUrl;
        public MediaPlayer Player => player;

        public async Task PlayAsync() {
            await StartStreamingAsync();
            await Task.Run(() => player.Play(media));
        }

        public Task PauseAsync() {
            return Task.Run(() => player.Stop());
        }

        public async Task StartStreamingAsync() {
            var status = await IsStreaming();
            if (status) return;
            await mqtt.PublishNoPayloadAsync(streamTopic);
        }

        public async Task StopStreamingAsync() {
            var status = await IsStreaming();
            if (status)
                await mqtt.PublishNoPayloadAsync(stopTopic);
        }

        public async Task CaptureImageAsync() {
            await mqtt.PublishNoPayloadAsync(captureTopic);
        }

        public async Task CaptureAsync() {
            var status = await IsStreaming();
            if (status == true) {
                await StopStreamingAsync()
                //.ContinueWith(t => Task.Delay(500))
                .ContinueWith((t) => CaptureImageAsync());
                //.ContinueWith(t => Task.Delay(1000))
                //.ContinueWith(t => StartStreamingAsync())
                //.ContinueWith(t => Thread.Sleep(4000))
                //.ContinueWith(t => PlayAsync());
            } else {
                await CaptureImageAsync();
            }

        }

        private async Task<bool> IsStreaming() {
            var rpcStreamStatusTopic = cfg.RpcStreamStatusTopic.Replace(cfg.Ph[0], stationId);
            var res = await mqtt.RpcCallNoPayload(rpcStreamStatusTopic);
            if (res.GetString() == "true") return true;
            else return false;
        }
    }

    public class VideoResolution {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
