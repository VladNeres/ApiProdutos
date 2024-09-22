using RabbitMQ.Client;
using ServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceBus.Base
{
    public class RabbitConfiguration : IRabbitConfiguration
    {
        private readonly IModel _channel;
        private readonly string _queueName;
        private readonly string _exchangeName;
        private readonly string _routingKey;

        public RabbitConfiguration(IConnection connection, string queueName, string exchangeName, string routingKey)
        {
            _queueName = queueName;
            _exchangeName = exchangeName;
            _routingKey = routingKey;


            _channel = connection.CreateModel();

            // Declaração da fila e exchange
            if (!string.IsNullOrEmpty(_exchangeName))
            {
                _channel.ExchangeDeclare(exchange: _exchangeName, type: "direct");
            }

            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: _queueName, exchange: _exchangeName, routingKey: _routingKey);
        }

        public async Task SendMessage<T>(T message)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            _channel.BasicPublish(exchange: _exchangeName,
                                  routingKey: _routingKey,
                                  basicProperties: null,
                                  body: body);
        }
    }
}
