using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Base
{
    public interface IPublisherBus
    {
        Task Publicar<T>(T message, string routingKey = null) where T : class;
    }
}
