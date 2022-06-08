using MQTTnet.Client;
using Common;
using System.Text;
using static Common.Helper;
using LogHub.NongNghiep;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

PrintLine("# Starting log hub ...", ConsoleColor.Yellow);

var config = ConfigManager<LogConfig>.Instance.Config;
var dbConfig = ConfigManager<DbConfig>.Instance.Config;

if (config.UseDatabase) {
    Connect(dbConfig);
    PrintLine("# Connected to database.", ConsoleColor.Yellow);
}

var mqtt = new ManagedClient(config);
mqtt.Client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;
mqtt.Client.ConnectedAsync += Client_ConnectedAsync;

await mqtt.ConnectAsync();
await mqtt.SubscribeAsync(config.LogTopic);

Thread.Sleep(-1);

// helper methods
// connect to database with XPO
void Connect(DbConfig config) {
    var host = config.Host;
    var userName = config.Username;
    var password = config.Password;
    var database = config.Database;

    string connection = MySqlConnectionProvider.GetConnectionString(host, userName, password, database);
    XpoDefault.DataLayer = XpoDefault.GetDataLayer(connection, AutoCreateOption.None);
}

async Task Client_ConnectedAsync(EventArgs arg) {
    await Task.Run(() => PrintLine("# Connected to server\r\n", ConsoleColor.Yellow));
}

async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg) {
    string topic = arg.ApplicationMessage.Topic;
    int i = topic.IndexOf("/");
    string stationId = topic.Remove(0, i + 1);
    string payload = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);

    await Task.Run(async () => {
        Print($"[{DateTime.Now}] ", ConsoleColor.White);
        PrintLine($"{stationId}", ConsoleColor.Green);
        PrintLine(payload, ConsoleColor.Yellow);

        if (config.UseDatabase) {
            UnitOfWork uow = new();
            Logs logs = new(uow) {
                LogTime = DateTime.Now,
                StationId = stationId,
                Data = payload,
            };
            await uow.CommitChangesAsync();
        }        
    });
}

public class LogConfig : MqttConfig {
    public string LogTopic { get; set; } = "log/#";
    public bool UseDatabase { get; set; } = true;
}

public class DbConfig {
    public string Host { get; set; } = "localhost";
    public string Username { get; set; } = "root";
    public string Password { get; set; } = "aion43";
    public string Database { get; set; } = "nongnghiep";
}