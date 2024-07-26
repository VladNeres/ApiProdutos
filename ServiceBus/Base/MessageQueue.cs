using System.Text.Json;
using static ServiceBus.RabbitMqEventBusSettings;

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


        public async Task PublishAsync<T>(T body, string routingKey = null) where T : class
        {
            try
            {
                if (string.IsNullOrEmpty(routingKey))
                    routingKey = _publisherConfiguration.RoutingKey;

                var jsonBody = JsonSerializer.Serialize(body);
                await _dynamicEventBus.PublishDynamicAsync(new DynamicIntegrationEvent(jsonBody, routingKey, _publisherConfiguration.Exchange)).ConfigureAwait(false);
            }
            catch (Exception)
            {

                return;
            }
        }

    }
}
