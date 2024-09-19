using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using ServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Publisher
{
    public class RabbitPublisherFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;

        public RabbitPublisherFactory(IConfiguration configuration)
        {
            _configuration = configuration;

           var hostname = _configuration["RabbitConnection:Connection:HostName"];
           var user =   _configuration["RabbitConnection:Connection:UserName"];
           var  pass = _configuration["RabbitConnection:Connection:Password"];
            // Configurações gerais de conexão com RabbitMQ
            
                var factory = new ConnectionFactory()
                {
                    HostName = hostname,
                    UserName = user,
                    Password = pass
                };

                _connection = factory.CreateConnection();
            
        }

        // Método para criar publicadores baseados no nó de configuração fornecido
        public IRabbitPublisher CreatePublisher(string publisherConfigKey)
        {
            var publisherConfig = _configuration.GetSection($"RabbitPublisher:{publisherConfigKey}");

            if (publisherConfig == null)
            {
                throw new ArgumentException($"Configuração para o publicador {publisherConfigKey} não encontrada.");
            }

            var queueName = publisherConfig["QueueName"];
            var exchangeName = publisherConfig["ExchangeName"];
            var routingKey = publisherConfig["RoutingKey"];

            return new RabbitPublisher(_connection, queueName, exchangeName, routingKey);
        }
    }
}
