using Common;
using MQTTnet;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

/// <summary>
/// Class for working with the camera
/// </summary>
public class RpiCamera {
    private readonly RpiConfig config;
    private readonly string imageUploadTopic;
    private readonly string startStreamCommand;
    private readonly RpcManagedClient mqtt;
    private readonly Func<string, LogType, Task> log;
    private Resolution imageResolution = new() { Width = 4056, Height = 3040 };
    private Resolution videoResolution = new() { Width = 1280, Height = 720 };
    private bool streaming = false;

    public RpiCamera(RpiConfig config, RpcManagedClient mqtt, Func<string, LogType, Task> log) {
        this.config = config;
        this.mqtt = mqtt;
        this.log = log;

        var stationId = config.StationId;
        imageUploadTopic = config.ImageTopic.Replace("{StationId}", stationId);
        startStreamCommand = config.RaspividFfmpeg.Replace("{StationId}", stationId);
    }

    /// <summary>
    /// Set resolution for image and video
    /// </summary>
    /// <param name="msg">the message received by mqtt</param>
    /// <param name="video">true for video, false for image</param>
    /// <returns></returns>
    public Task SetImageResolution(MqttApplicationMessage msg) {
        if (msg.ContentType == "json") {
            string json = Encoding.UTF8.GetString(msg.Payload);
            Resolution? temp = JsonSerializer.Deserialize<Resolution>(json);
            if (temp != null) {
                imageResolution = temp.Value;
                return log($"Resolution set to {imageResolution.Width}x{imageResolution.Height}", LogType.Information);
            }
        }
        return Task.CompletedTask;
    }

    public Task SetVideoResolution(Resolution res) {
        videoResolution = res;
        return log($"Video resolution set to {res.Width}x{res.Height}", LogType.Information);
    }

    /// <summary>
    /// Start streaming, run <code>raspivid</code> piped to <code>ffmpeg</code> in bash
    /// </summary>
    /// <returns></returns>
    public async Task StartStreamingAsync() {
        string command = startStreamCommand.Replace("{Width}", videoResolution.Width.ToString()).Replace("{Height}", videoResolution.Height.ToString());
        await RpiBash.RunBashCommandAsync(config, command);
        await log.Invoke("Start streaming", LogType.Information);
        streaming = true;
    }

    /// <summary>
    /// Stop streaming, run pkill for raspivid and ffmpeg
    /// </summary>
    /// <returns></returns>
    public async Task StopStreamingAsync() {
        await RpiBash.RunBashCommandsAsync(config, config.KillRaspivid, config.KillFfmpeg);
        await log.Invoke("Stop streaming", LogType.Information);
        streaming = false;
    }

    internal byte[] GetStreamingStatus() {
        if (streaming) return "true".GetBytes();
        else return "false".GetBytes();
    }

    /// <summary>
    /// Capture image, run raspistill in bash. If streaming than stop streaming first.
    /// </summary>
    /// <param name="stopStreaming">true if capture while treaming, false if capture stand-alone</param>
    /// <returns></returns>
    public async Task CaptureAsync(bool stopStreaming = true) {
        //var path = Directory.GetCurrentDirectory();
        var fileName = $@"{config.StationId}_{DateTime.Now.Ticks}.jpg";
        //var fullPath = Path.Combine(path, fileName);
        var raspistillCommand = config.Raspistill
            .Replace("{FileName}", fileName)
            .Replace("{Width}", imageResolution.Width.ToString())
            .Replace("{Height}", imageResolution.Height.ToString());
        // capture image while streaming
        if (stopStreaming) {
            await StopStreamingAsync()
            .ContinueWith(async t => {
                await RpiBash.RunBashCommandAsync(config, raspistillCommand, true);
                await log.Invoke("Image Captured", LogType.Information);
            })
            .ContinueWith(async t => {
                await StartStreamingAsync();
                await log.Invoke("Data Tranfer Started", LogType.Information);
                await UploadImageAsync(fileName);
            });
        } // capture image while not streaming
        else {
            await RpiBash.RunBashCommandAsync(config, raspistillCommand, true)
                .ContinueWith(async t => {
                    await log.Invoke("Image Captured", LogType.Information);
                    await UploadImageAsync(fileName);
                    await log.Invoke("Data Tranfer Started", LogType.Information);
                });

        }
    }

    /// <summary>
    /// Upload a file to mqtt broker and delete the file, used for capture images
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private async Task UploadImageAsync(string fileName) {
        byte[] buffer = File.ReadAllBytes(fileName);
        await log.Invoke($"Uploading: {buffer.Length} bytes", LogType.Information);
        await mqtt.PublishAsync(new MqttApplicationMessageBuilder()
            .WithTopic(imageUploadTopic)
            .WithPayload(buffer)
            .WithCorrelationData(Encoding.UTF8.GetBytes(fileName)))
        .ContinueWith(t => File.Delete(fileName));

    }
}

/// <summary>
/// Resolution for image and video
/// </summary>
public struct Resolution {
    public Resolution() { }

    public Resolution(int width, int height) {
        Width = width;
        Height = height;
    }

    public int Width { get; set; } = 4056;
    public int Height { get; set; } = 3040;
}
