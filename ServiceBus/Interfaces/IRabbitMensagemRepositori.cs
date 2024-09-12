using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Interfaces
{
    public interface IRabbitMensagemRepositori
    {
        Task SendMessage<T>(string queueName, T message);
    }
}
