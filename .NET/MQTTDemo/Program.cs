// See https://aka.ms/new-console-template for more information
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Internal;

Console.WriteLine("Hello, World!");
// MqttClient mqttClient = new();

var mqttFactory = new MqttFactory();
using var client = mqttFactory.CreateMqttClient();
var options = new MqttClientOptionsBuilder().WithTcpServer("broker.hivemq.com").Build();
await client.ConnectAsync(options);
// await client.StartAsync(options);
// await client.EnqueueAsync("Topic", options);

// public class MqttClientCom : ComBase
// {

// }

//Bard 使用案例
var mqttClient = new MqttFactory().CreateMqttClient();
var options1 = new MqttClientOptionsBuilder()
    .WithTcpServer("mqtt.eclipse.org", 1883)
    .WithClientId("YourClientId")
    .Build();
mqttClient.ConnectAsync(options1).Wait();

await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("YourTopic").Build());

var message = new MqttApplicationMessage()
{
    PayloadSegment = new byte[1024],
    Topic = "topic",
};
mqttClient.PublishAsync(message).Wait();
await mqttClient.DisconnectAsync();

