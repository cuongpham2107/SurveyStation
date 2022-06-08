using MQTTnet;
using MQTTnet.Client;
using System.IO.Ports;
using System.Text;
using Common;

public class RpiSerial {
    SerialPort port = new();
    readonly RpiConfig config;
    readonly Func<string, LogType, Task> log;

    public Func<string, LogType, Task>? Log { get; set; }

    public RpiSerial(RpiConfig config, Func<string, LogType, Task> log) {
        this.config = config;
        this.log = log;
        port.PortName = config.PortName;
        port.BaudRate = config.BaudRate;
    }

    public async Task WriteGcodeAsync(MqttApplicationMessage msg) {
        string gcode = Encoding.UTF8.GetString(msg.Payload);
        if (port.IsOpen) {
            await Task.Run(() => {
                port.WriteLine(gcode);
            });
        } else {
            try {
                port.Open();
                await Task.Run(() => {
                    port.WriteLine(gcode);
                });
            } catch (Exception ex) {
                await log.Invoke($"Error opening port: {ex.Message}", LogType.Error);
            }
        }
    }

    public async Task OpenPortAsync() {
        if (!port.IsOpen) {
            try {
                port.Open();
            } catch (Exception exc) {
                await log.Invoke($"Error openning port: {exc.Message}", LogType.Error);
            }
        }
    }

    public async Task ClosePortAsync() {
        if (port.IsOpen) {
            try {
                port.Close();
            } catch (Exception exc) {
                await log.Invoke($"Error closing port: {exc.Message}", LogType.Error);
            }
        }
    }

    public async Task ResetPortAsync() {
        port = new() {
            PortName = config.PortName,
            BaudRate = config.BaudRate
        };
        await log.Invoke("The port is reset and closed", LogType.Information);
    }
}