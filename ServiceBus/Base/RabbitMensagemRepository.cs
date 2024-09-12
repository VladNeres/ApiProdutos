using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using ServiceBus;
using ServiceBus.Interfaces;
using System.Text;
using System.Text.Json;

public class RabbitMensagemRepository : IRabbitMensagemRepositori
{
    private readonly string _hostName;
    private readonly string _password;
    private readonly string _user;
    private readonly string _exchangeName;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMensagemRepository(IOptions<PublisherConfiguration> options)
    {
        _hostName = options.Value.HostName;
        _user = options.Value.UserName;
        _password = options.Value.Password;
        _exchangeName = options.Value.ExchangeName;

        var factory = new ConnectionFactory()
        {
            HostName = options.Value.HostName,
            Password = options.Value.Password,
            UserName = options.Value.UserName
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        if (!string.IsNullOrEmpty(_exchangeName))
        {
            _channel.ExchangeDeclare(exchange: _exchangeName, type: "direct");
        }
    }

    public Task SendMessage<T>(string queueName, T message)
    {
        // Declara a fila caso ela não exista
        _channel.QueueDeclare(queue: queueName,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        // Publica a mensagem na fila (ou exchange, caso especificado)
        if (string.IsNullOrEmpty(_exchangeName))
        {
            _channel.BasicPublish(exchange: queueName,
                                  routingKey: queueName,
                                  basicProperties: null,
                                  body: body);
        }
        else
        {
            _channel.BasicPublish(exchange: _exchangeName,
                                  routingKey: queueName,
                                  basicProperties: null,
                                  body: body);
        }

        Dispose();
       return Task.CompletedTask;
    }

    public void Dispose()
    {
        _channel.Close();
        _connection.Close();
    }
}

