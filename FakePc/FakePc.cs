using Common;
using MQTTnet.Protocol;
using System.Text;

Console.WriteLine("Fake PC");

MqttConfig config = new();
RpcManagedMqtt client = new(config);

client.LogAsync += (s, l) => Task.Run(() => Console.WriteLine(s));

await client.ConnectAsync();

while (true) {
    Console.Write("Station ID: ");
    var stationId = Console.ReadLine();
    while (true) {
        Console.Write("> ");
        var command = Console.ReadLine();
        if (string.IsNullOrEmpty(command)) break;
        try {
            var res = await client.RpcCallNoPayload($"{stationId}.{command}");
            await client.PublishNoPayloadAsync($"{stationId}/{command}");
            Console.WriteLine(res.GetString());
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }

    }
}