using MQTTnet.Client;
using Common;
using static Common.Helper;
using DevExpress.Xpo;
using ImageHub.NongNghiep;
using DevExpress.Xpo.DB;
using System.Text;

PrintLine("# Starting image hub ...", ConsoleColor.Yellow);

var config = ConfigManager<ImageConfig>.Instance.Config;
var dbConfig = ConfigManager<DbConfig>.Instance.Config;

if (config.UseDatabase) {
    Connect(dbConfig);
    PrintLine("# Connected to database.", ConsoleColor.Yellow);
}

var mqtt = new ManagedClient(config);
mqtt.Client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;
mqtt.Client.ConnectedAsync += Client_ConnectedAsync;

await mqtt.ConnectAsync();
await mqtt.SubscribeAsync(config.ImageTopic);

Thread.Sleep(-1);

// helper methods

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
    byte[] temp = arg.ApplicationMessage.Payload;
    await Task.Run(async () => {
        var i = topic.IndexOf("/");
        var stationId = @$"{topic.Remove(0, i + 1)}";
        var fileName = Encoding.UTF8.GetString(arg.ApplicationMessage.CorrelationData); // $@"{stationId}_{DateTime.Now.Ticks}.jpg";
        var fullFileName = Path.Combine(config.ImageFolder, fileName);

        Print($"[{DateTime.Now}]");
        PrintLine($" {stationId}", ConsoleColor.Green);
        PrintLine($"Saving to '{fullFileName}'");

        await File.WriteAllBytesAsync(fullFileName, temp);

        if (config.UseDatabase) {
            UnitOfWork uow = new();
            DataImages di = new(uow) {
                Name = fileName,
                FileImage = fullFileName,
                TimestartCapture = DateTime.Now,
                StationId = stationId
            };
            await uow.CommitChangesAsync();
        }
    });
}

public class ImageConfig : MqttConfig {
    public string ImageTopic { get; set; } = "img/#";
    public string ImageFolder { get; set; } = @"C:\Users\TuHocICT\Downloads";
    public bool UseDatabase { get; set; } = true;
}

public class DbConfig {
    public string Host { get; set; } = "localhost";
    public string Username { get; set; } = "root";
    public string Password { get; set; } = "aion43";
    public string Database { get; set; } = "nongnghiep";
}