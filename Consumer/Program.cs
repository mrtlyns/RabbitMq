using Consumer;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest",
};

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "log_queue",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, mq) =>
    {
        var body = mq.Body.ToArray();
        var logMessageString = Encoding.UTF8.GetString(body);
        Console.WriteLine($"Log message received: {logMessageString}");

        var logMessage = JsonSerializer.Deserialize<LogModel>(logMessageString);

        // Örn: veri tabanına ekle
        // Örn: dosyaya kaydet
    };

    channel.BasicConsume(queue: "log_queue",
                         autoAck: true, //true ise mesaj otomatik olarak kuyruktan silinir
                         consumer: consumer);
    Console.ReadLine();
}