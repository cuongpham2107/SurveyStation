using MMALSharp.Common.Utility;
using MMALSharp.Common;
using MMALSharp.Components;
using MMALSharp.Handlers;
using MMALSharp.Ports;
using MMALSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpiControl {
    internal class _temp {
        public async Task StartRTMPStreaming(byte[] bytes) {
            //MMALCamera cam = MMALCamera.Instance;
            try {

                MMALCamera cam = MMALCamera.Instance;

                // An RTMP server needs to be listening on the address specified in the capture handler. I have used the Nginx RTMP module for testing.    
                using (var ffCaptureHandler = FFmpegCaptureHandler.RTMPStreamer(config.StationId, config.RtmpServer))
                using (var vidEncoder = new MMALVideoEncoder())
                using (var renderer = new MMALVideoRenderer()) {
                    MMALCameraConfig.VideoResolution = Resolution.As03MPixel;
                    cam.ConfigureCameraSettings();

                    var portConfig = new MMALPortConfig(MMALEncoding.H264, MMALEncoding.I420, 10, MMALVideoEncoder.MaxBitrateLevel4, null);

                    // Create our component pipeline. Here we are using the H.264 standard with a YUV420 pixel format. The video will be taken at 25Mb/s.
                    vidEncoder.ConfigureOutputPort(portConfig, ffCaptureHandler);

                    cam.Camera.VideoPort.ConnectTo(vidEncoder);
                    cam.Camera.PreviewPort.ConnectTo(renderer);

                    // Camera warm up time
                    await Task.Delay(2000);

                    var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
                    //BackgroundWorker bgw = new();
                    //bgw.DoWork += (s, e) => { var c = e.Argument as MMALCamera; c.ProcessAsync(cam.Camera.VideoPort, CancellationToken.None); };
                    //bgw.RunWorkerAsync();

                    // Take video for 3 minutes.
                    await cam.ProcessAsync(cam.Camera.VideoPort, cts.Token);
                }


                //// An RTMP server needs to be listening on the address specified in the capture handler. I have used the Nginx RTMP module for testing.    
                //using var ffCaptureHandler = FFmpegCaptureHandler.RTMPStreamer(config.StationId, config.RtmpServer);
                //using var vidEncoder = new MMALVideoEncoder();
                //using var renderer = new MMALVideoRenderer();
                //    MMALCameraConfig.VideoResolution = Resolution.As1080p;
                //cam.ConfigureCameraSettings();
                //var portConfig = new MMALPortConfig(MMALEncoding.H264, MMALEncoding.I420, 10, MMALVideoEncoder.MaxBitrateLevel4, null);
                //// Create our component pipeline. Here we are using the H.264 standard with a YUV420 pixel format. The video will be taken at 25Mb/s.
                //vidEncoder.ConfigureOutputPort(portConfig, ffCaptureHandler);
                //cam.Camera.VideoPort.ConnectTo(vidEncoder);
                //cam.Camera.PreviewPort.ConnectTo(renderer);
                //// Camera warm up time
                //await Task.Delay(2000);
                ////cts = new CancellationTokenSource(TimeSpan.FromMinutes(3));                
                //await cam.ProcessAsync(cam.Camera.VideoPort, cts.Token); // CancellationToken.None
            } catch (Exception e) {
                Log?.Invoke($"* Error starting streaming: {e.Message}");
            }
        }

        public Task StopRTMPStreaming(byte[] bytes) {
            MMALCamera cam = MMALCamera.Instance;
            try {
                cts.Cancel();
                //cam.ForceStop(cam.Camera.VideoPort);
                //await cam.ProcessAsync(cam.Camera.VideoPort, cts.Token);
            } catch (Exception e) {
                Log?.Invoke($"* Error stopping streaming: {e.Message}");
            }
            return Task.CompletedTask;
        }

        public async Task ShotToFileAsync(byte[] data) {
            try {
                var cam = MMALCamera.Instance;
                //set max image resolution 4056x3040
                //TODO client may set the resolution in command
                MMALCameraConfig.StillResolution = new MMALSharp.Common.Utility.Resolution(4056, 3040);
                var imageFile = $"{DateTime.Now.Ticks}.jpg";
                var handler = new ImageStreamCaptureHandler(imageFile);
                await cam.TakePicture(handler, MMALEncoding.JPEG, MMALEncoding.I420)
                .ContinueWith(async t => {
                    handler.Dispose();
                    var bytes = File.ReadAllBytes(imageFile);
                    await Log?.Invoke($"< Image captured. Starting tranfer {bytes.Length} bytes.");
                    await Upload?.Invoke(imageTopic, bytes);
                })
                .ContinueWith(t => { File.Delete(imageFile); });

            } catch (Exception exc) {
                await Log?.Invoke($"* Error capturing: {exc.Message}");
            }
        }

        public async Task ShotToMemoryAsync(byte[] data) {
            try {
                var cam = MMALCamera.Instance;
                //set max image resolution 4056x3040
                //TODO client may set the resolution in command
                MMALCameraConfig.StillResolution = new Resolution(4056, 3040);
                using (var handler = new InMemoryCaptureHandler()) {
                    await cam.TakePicture(handler, MMALEncoding.JPEG, MMALEncoding.I420)
                    .ContinueWith(async t => {
                        cam.Cleanup();
                        handler.Dispose();
                        var bytes = handler.WorkingData.ToArray();
                        await Log?.Invoke($"< Image captured. Starting tranfer {bytes.Length} bytes.");
                        await Upload?.Invoke(imageTopic, bytes);
                    });
                }

            } catch (Exception exc) {
                await Log?.Invoke($"* Error capturing: {exc.Message}");
            }
        }

        public async Task ShotToMemoryAsyncTest(byte[] data) {
            try {
                var bytes = File.ReadAllBytes(config.TestImage);
                await Log?.Invoke($"< Image captured. Starting tranfer {bytes.Length} bytes.");
                await Upload?.Invoke(imageTopic, bytes);
            } catch (Exception exc) {
                await Log?.Invoke($"* Error capturing: {exc.Message}");
            }
        }
    }
}
