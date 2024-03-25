using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Base
{
    public class MessageQueue
    {
        protected readonly IDynamicEventBus _dynamicEventBus;
        private readonly PublisherConfiguration _publisherConfiguration;


        public MessageQueue(IDynamicEventBus dynamicEventBus, PublisherConfiguration publiisherConfiguration)
        {
            _dynamicEventBus = dynamicEventBus;
            _publisherConfiguration = publiisherConfiguration;
        }


        public  async Task PublishAsync<T>(T body, string routingKey = null) where T : class
        {
            try
            {
                if(string.IsNullOrEmpty(routingKey))
                    routingKey - publisherCon
            }
            catch (Exception)
            {

                throw;
            }
        } 
    }
}
