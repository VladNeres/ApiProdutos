using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceBus.Base
{
    public class MessageQueue
    {

        private readonly IDynamicEventBus _dynamicEventBus;
        private readonly PublisherConfiguration _publisherConfiguration;

        public MessageQueue(IDynamicEventBus dynamicEventBus, PublisherConfiguration publisherConfiguration)
        {
            _dynamicEventBus = dynamicEventBus;
            _publisherConfiguration = publisherConfiguration;
        }


        public async Task PublishAsync<T>( T body, string routingKey = null) where T : class
        {
            try
            {
                if(string.IsNullOrEmpty(routingKey))
                    routingKey = _publisherConfiguration.RoutingKey;

                var jasonBody = JsonSerializer.Serialize(body);
                await _dynamicEventBus.PublishDynamicAsync( new DynamicIntegrationEvent(jasonBody, routingKey, _publisherConfiguration.Exchange)).ConfigureAwait(false);
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
