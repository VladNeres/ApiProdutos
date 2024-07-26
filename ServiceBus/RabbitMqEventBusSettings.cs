namespace ServiceBus
{
    public class RabbitMqEventBusSettings
    {

        public IList<QueueConfiguration> QueueConfigurations { get; set; } = new List<QueueConfiguration>();
        public IList<PublisherConfiguration> PublisherConfigurations { get; set; } = new List<PublisherConfiguration>();

        public QueueConfiguration GetQueueConfigurationByEventId(Guid eventId)
        {
            return QueueConfigurations?.Where(x => x.EventId == eventId).SingleOrDefault();
        }

        public QueueConfiguration AddDefaultConfigurationEventName(string eventName, string exchange = "")
        {
            var queueConfiguration = new QueueConfiguration() { EventName = eventName, Exchange = exchange };
            QueueConfigurations.Add(queueConfiguration);

            return queueConfiguration;

        }

        public PublisherConfiguration GetPublisherConfiguration(string name)
        {
            return PublisherConfigurations?.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
        }

        public class PublisherConfiguration
        {
            public string Name { get; set; }
            public string ConnectionName { get; set; }
            public string Exchange { get; set; }
            public string RoutingKey { get; set; }
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
            public int ResolveresNumber { get; set; }
            public int? ScaleOutMaxResolveresNumber { get; set; }
            public int ScaleOutMessageCountNumber { get; set; } = 1000;
            public bool SholdRetry { get; set; } = false;
            public string RetryEvent { get; set; }
            public string RetryHeader { get; set; } = "retry-number";
            public int RetryCount { get; set; } = 10;
            public bool UseStringArgsEventMessageType { get; set; } = false;
            public bool MultipleAck { get; set; } = false;
            public bool UseRedeliver { get; set; } = false;
        }

    }
}
