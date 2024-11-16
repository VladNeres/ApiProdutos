using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using ServiceBus.Base;
using ServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ServiceBus.Publisher
{
    public class ProdutoPublisher : IProdutoPublisher
    {
        private readonly IRabbitPublisherFactory _rabbitPublisherFactory;

        public ProdutoPublisher(RabbitPublisherFactory rabbitConfig)
        {
            _rabbitPublisherFactory = rabbitConfig;
        }
        public async Task SendMessage<T>(T message)
        {
            if(message == null) throw new ArgumentNullException("Erro no envio da mensagem");
            
            var publisher = _rabbitPublisherFactory.CreatePublisher("CriarProdutos");

            if (publisher == null)
                throw new InvalidOperationException("Não foi possível se conectar ao serviço de mensageria");

            await publisher.SendMessage(message);
       
        }
    }
}
