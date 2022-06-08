using System.Diagnostics;
using System.Text;
/// <summary>
/// Class for running bash command from C#
/// </summary>
public class RpiBash {
    private readonly RpiConfig config;

    public RpiBash(RpiConfig config) {
        this.config = config;
    }

    /// <summary>
    /// Run a single command in bash console
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public async Task RunBashCommandAsync(MQTTnet.MqttApplicationMessage msg) {
        string arguments = Encoding.UTF8.GetString(msg.Payload);
        await RunBashCommandAsync(config, arguments);
    }

    /// <summary>
    /// Run a single command in bash console
    /// </summary>
    /// <param name="config"></param>
    /// <param name="arguments"></param>
    /// <param name="wait">time to wait for exit (ms), 0 means no waiting</param>
    /// <returns></returns>
    public static async Task RunBashCommandAsync(RpiConfig config, string arguments, bool wait = false) {
        ProcessStartInfo psi = new() {
            FileName = "bash",
            Arguments = "-c \"" + arguments + "\"",
            RedirectStandardOutput = config.RedirectStandardOutput,
            RedirectStandardError = config.RedirectStandardError,
            UseShellExecute = config.UseShellExecute
        };
        await Task.Run(() => {
            Process p = Process.Start(psi);
            if (p != null && wait) p.WaitForExit();
        });
    }

    /// <summary>
    /// Run multiple commands in bash console
    /// </summary>
    /// <param name="config"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public static async Task RunBashCommandsAsync(RpiConfig config, params string[] arguments) {
        List<Process> processes = new();
        foreach (var arg in arguments) {
            ProcessStartInfo psi = new() {
                FileName = "bash",
                Arguments = "-c \"" + arg + "\"",
                RedirectStandardOutput = config.RedirectStandardOutput,
                RedirectStandardError = config.RedirectStandardError,
                UseShellExecute = config.UseShellExecute
            };
            processes.Add(new() { StartInfo = psi });
        }
        await Task.Run(() => processes.ForEach(p => p.Start()));
    }
}
