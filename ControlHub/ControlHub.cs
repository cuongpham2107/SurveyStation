using MQTTnet;
using MQTTnet.Client;
using Common;
using MQTTnet.Extensions.ManagedClient;

var config = ConfigManager<MqttConfig>.Instance.Config;

var managedClient = new ManagedClient(config);
await managedClient.ConnectAsync();

while (true) {
    Console.Write("Station: ");
    var station = Console.ReadLine();
    while (true) {
        Console.Write("> ");
        var command = Console.ReadLine();
        if (command == "") break;
        var index = command.IndexOf(" ");
        if (index > 0) {
            var items = command.Split(' ', 2, StringSplitOptions.TrimEntries);
            var topic = $"{station}{items[0]}";
            var payload = items[1];
            await managedClient.PublishStringAsync($"{topic}", payload);
        } else {
            var topic = $"{station}{command}";
            await managedClient.PublishNoPayloadAsync(topic);
        }

    }

}