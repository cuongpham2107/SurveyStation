using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;
using System.Text.Json;
using MQTTnet.Packets;

namespace Common {
    public class ManagedClient {
        readonly protected ManagedMqttClient client = new MqttFactory().CreateManagedMqttClient();
        readonly protected MqttConfig config;

        /// <summary>
        /// The underlying managed mqtt client. Use this property to handle events.
        /// </summary>
        public ManagedMqttClient Client => client;

        public ManagedClient(MqttConfig config) {
            this.config = config;
            //client = new MqttFactory().CreateManagedMqttClient();            
        }

        #region STAND-ALONE CLIENT

        /// <summary>
        /// Event log
        /// </summary>
        public event Func<string, LogType, Task>? LogAsync;

        /// <summary>
        /// Actions for topics
        /// </summary>
        public Dictionary<string, Func<MqttApplicationMessage, Task>> Handlers { get; set; } = new();

        /// <summary>
        /// Add handler action for each topic
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="action"></param>
        public void AddHandler(string topic, Func<MqttApplicationMessage, Task> action) {
            Handlers.Add(topic, action);
        }

        /// <summary>
        /// Start the program loop without rpc support
        /// </summary>
        /// <param name="qos"></param>
        /// <returns></returns>
        public async Task StartAsync(MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce) {
            client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;
            client.ConnectedAsync += Client_ConnectedAsync;

            await ConnectAsync();
            await SubscribeAsync(Handlers.Keys.ToArray());
        }

        /// <summary>
        /// Run when mqtt client connected to broker
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        protected async Task Client_ConnectedAsync(EventArgs arg) {
            await LogAsync?.Invoke("Connected to broker. Waiting for commands ...", LogType.System);
        }

        /// <summary>
        /// The program loop with normal subscriptions
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        protected async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg) {
            string topic = arg.ApplicationMessage.Topic;
            // if this is a rpc call - abort
            if (topic.StartsWith("MQTTnet.RPC/")) { return; }

            var command = topic.Remove(0, 36);

            var type = arg.ApplicationMessage.ContentType;
            if (type == "string" || type == "json") {
                string payloadString = arg.ApplicationMessage.Payload.GetString();
                await LogAsync?.Invoke($"{command} {payloadString}", LogType.Command);
            } else {
                await LogAsync?.Invoke(command, LogType.Command);
            }

            try {
                await Handlers[topic].Invoke(arg.ApplicationMessage);
            } catch (Exception e) {
                // catch any exception so that program does not crash
                await LogAsync?.Invoke(e.Message, LogType.Error);
            }
        }

        #endregion

        #region MANAGED CLIENT
        /// <summary>
        /// Start the mqtt client
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync() {
            var optionBuilder = new MqttClientOptionsBuilder()
                //.WithClientId(config.ClientId)
                .WithTcpServer(config.Uri, config.Port)
                .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
                .WithWillQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce)
                .WithCleanSession();
            var options = optionBuilder.Build();
            var managedOptions = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(options)
                .Build();
            await client.StartAsync(managedOptions);
        }

        /// <summary>
        /// Subscirbe to a topic
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qos"></param>
        /// <returns></returns>
        public async Task SubscribeAsync(string topic, MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce) {
            var topicFilter = new MqttTopicFilterBuilder()
                .WithTopic(topic)
                .WithQualityOfServiceLevel(qos)
                .Build();
            await client.SubscribeAsync(new[] { topicFilter });
        }

        /// <summary>
        /// Subscribe to multiple normal topics
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="qos"></param>
        /// <returns></returns>
        public async Task SubscribeAsync(string[] topics, MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce) {
            List<MqttTopicFilter> filters = new();
            foreach (var topic in topics) {
                filters.Add(new MqttTopicFilterBuilder()
                    .WithTopic(topic)
                    .WithQualityOfServiceLevel(qos)
                    .Build());
            }
            await client.SubscribeAsync(filters);
        }

        /// <summary>
        /// Unsubscribe from a topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task UnsubscribeAsync(string topic) {
            await client.UnsubscribeAsync(topic);
        }

        /// <summary>
        /// Publish message using message builder
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public async Task PublishAsync(MqttApplicationMessageBuilder builder) {
            await client.EnqueueAsync(builder.Build());
        }

        /// <summary>
        /// Publish to a topic with object payload as a json string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="topic"></param>
        /// <param name="payload"></param>
        /// <param name="retainFlag"></param>
        /// <param name="qos"></param>
        /// <returns></returns>
        public async Task PublishJsonAsync<T>(string topic, T payload, bool retainFlag = false, MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce) {
            var jsonPayload = JsonSerializer.Serialize(payload);
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(jsonPayload)
                .WithContentType("json")
                .WithQualityOfServiceLevel(qos)
                .WithRetainFlag(retainFlag)
                .Build();
            await client.EnqueueAsync(message);
        }

        /// <summary>
        /// Publish to a topic with string payload
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="payload"></param>
        /// <param name="retainFlag"></param>
        /// <param name="qos"></param>
        /// <returns></returns>
        public async Task PublishStringAsync(string topic, string payload, bool retainFlag = false, MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce) {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithContentType("string")
                .WithQualityOfServiceLevel(qos)
                .WithRetainFlag(retainFlag)
                .Build();
            await client.EnqueueAsync(message);
        }

        /// <summary>
        /// Publish to a topic with byte array payload
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="payload"></param>
        /// <param name="retainFlag"></param>
        /// <param name="qos"></param>
        /// <returns></returns>
        public async Task PublishBinaryAsync(string topic, byte[] payload, bool retainFlag = false, MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtLeastOnce) {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithContentType("bytes")
                .WithQualityOfServiceLevel(qos)
                .WithRetainFlag(retainFlag)
                .Build();
            await client.EnqueueAsync(message);
        }

        /// <summary>
        /// Publish to a topic without payload. A zero byte will be used as payload (as MQTT does not allow empty payload)
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="retainFlag"></param>
        /// <param name="qos"></param>
        /// <returns></returns>
        public async Task PublishNoPayloadAsync(string topic, bool retainFlag = false, MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce) {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(new byte[] { 0 })
                .WithContentType("0")
                .WithQualityOfServiceLevel(qos)
                .WithRetainFlag(retainFlag)
                .Build();
            await client.EnqueueAsync(message);
        }

        #endregion
    }

}