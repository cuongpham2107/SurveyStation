using Common;
using MQTTnet.Protocol;
using System.Text;

Console.WriteLine("Fake Rpi");

RpiConfig config = new() { StationId = "2c83a876-8700-4264-b488-80b8ac0d3f03" };
RpcManagedMqtt client = new(config);

Console.WriteLine($"Station ID: {config.StationId}");

client.LogAsync += (s, l) => Task.Run(() => Console.WriteLine(s));
client.AddRpcHandler(config.StationId, "date", msg => DateTime.Now.ToLongDateString().GetBytes());
client.AddRpcHandler(config.StationId, "time", msg => DateTime.Now.ToLongTimeString().GetBytes());
client.AddRpcHandler(config.StationId, "day", msg => DateTime.Today.DayOfWeek.ToString().GetBytes());

client.AddHandler($"{config.StationId}/date", async msg => Console.WriteLine("Date"));

client.RpcHandlers[$"{config.StationId}.sayhi"] = msg => "OK - hi".GetBytes();
client.RpcHandlers[$"{config.StationId}.sayhello"] = msg => "OK - hello".GetBytes();

await client.StartAsyncWithRpc(MqttQualityOfServiceLevel.AtMostOnce);

Thread.Sleep(-1);

class RpiConfig : MqttConfig {
    public string StationId { get; set; } = Guid.NewGuid().ToString();
}