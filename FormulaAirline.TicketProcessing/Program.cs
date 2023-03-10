using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Welcome to the ticketing service");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/"
};

var connection = factory.CreateConnection();

using var  channel=connection.CreateModel();

channel.QueueDeclare("bookings",durable:true,exclusive:true);

var consumer=new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    //getting my byte[]
    var body = eventArgs.Body.ToArray();

    var message=Encoding.UTF8.GetString(body);

    Console.WriteLine($"New ticket processin is initiated for: {message}");

    channel.BasicConsume("booking", true, consumer);
    
    Console.ReadKey();
};