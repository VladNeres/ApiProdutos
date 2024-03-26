using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus
{
    public class RabbitEventBusSettings
    {
        public IList<QueueConfiguration> QueueConfigurations { get; set; } = new List<QueueConfiguration>();
        public IList<PublisherConfiguration> PublisherConfigurations { get; set; } = new List<PublisherConfiguration>();

        public QueueConfiguration GetQueueConfigurationByEventName(string? eventName, string? exchange)
        {
            return QueueConfigurations?.Where(x => x.EventName == eventName && x.Exchange == exchange).SingleOrDefault();
        }

        public QueueConfiguration GetQueueConfigurationByEventID(Guid eventId)
        {
            return QueueConfigurations?.Where(x => x.EventId == eventId).SingleOrDefault();
        }

        public QueueConfiguration GetQueueConfigurationForEventName(string eventName, string exchange = "")
        {
            var queueCnfiguration = new QueueConfiguration() { EventName = eventName, Exchange = exchange };
            QueueConfigurations.Add(queueCnfiguration);

            return queueCnfiguration;
        }

        public PublisherConfiguration GetPublisherConfiguration(string name)
        {
            return PublisherConfigurations?.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
        }
    }

    public class PublisherConfiguration
    {
        public string? Name { get; set; }
        public string? ConnectionName { get; set; }
        public string?  Exchange { get; set; }
        public string? RoutingKey { get; set; }
    }

    public class QueueConfiguration
    {
        public QueueConfiguration()
        {
            EventId = Guid.NewGuid();
        }

        public Guid EventId { get; }

        public string EventName { get; set; }
        public string Exchange { get; set; } = string.Empty;
        public ushort PrefetchSize { get; set; } = 20;
        public int ResolveresNumber { get; set; } = 1;
        public int ScaleOutMaxResolveresNumber { get; set; } = 1000;
        public bool ShouldRetry { get; set; } = false;
        public string RetryEvent { get; set; }
        public string RetryHeader { get; set; } = "retry-number";
        public int RetryCount { get; set; } = 10;
        public bool UseStringEventMessageType { get; set; } = false;
        public bool MultpleAck { get; set; } = false;
        public bool UseRedeliver { get; set; } = false;

    }
}
