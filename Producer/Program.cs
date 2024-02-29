using System;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using Producer;

class Program
{
    static void Main()
    {
        var connectionFactory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
        };

        using (var connection = connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "log_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            while (true)
            {
                Console.Write("Enter log message (type 'exit' to quit): ");
                string userMessage = Console.ReadLine();

                if (userMessage.ToLower() == "exit")
                {
                    break;
                }

                var logMessage = new  LogModel() { LogType = "Info", LogMessage = userMessage };

                string logMessageJson = JsonSerializer.Serialize(logMessage);

                var body = Encoding.UTF8.GetBytes(logMessageJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "log_queue",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine("Log message sent to RabbitMQ.");
            }
        }
    }
}
