using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using ServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Base
{
    public class RabbitPublisherFactory : IRabbitPublisherFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;

        public RabbitPublisherFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            var hostname = _configuration["RabbitConnection:Connection:HostName"];
            var user = _configuration["RabbitConnection:Connection:UserName"];
            var pass = _configuration["RabbitConnection:Connection:Password"];
            // Configurações gerais de conexão com RabbitMQ

            var factory = new ConnectionFactory()
            {
                HostName = hostname,
                UserName = user,
                Password = pass,
            };

            try
            {
                _connection = factory.CreateConnection();

            }
            catch (Exception)
            {
                Console.WriteLine($"Não foi possível se conectar ao serviço de mensageria");

                return;
            }

        }

        // Método para criar publicadores baseados no nó de configuração fornecido
        public IRabbitConfiguration CreatePublisher(string publisherConfigKey)
        {
            var publisherConfig = _configuration.GetSection($"RabbitPublisher:{publisherConfigKey}");

            if (publisherConfig == null)
            {
                throw new ArgumentException($"Configuração para o publicador {publisherConfigKey} não encontrada.");
            }

            var queueName = publisherConfig["QueueName"];
            var exchangeName = publisherConfig["ExchangeName"];
            var routingKey = publisherConfig["RoutingKey"];

            if (_connection == null)
                return null;

            return new RabbitConfiguration(_connection, queueName, exchangeName, routingKey);
        }
    }
}
