using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus
{
    public interface IDynamicEventBus
    {
        void PublishDynamic(DynamicIntegrationEvent eventData, int retryCount = 0, string retryHeader = "retry-number", bool useStringEventMessageType = false);

        Task PublishDynamicAsync(DynamicIntegrationEvent eventData, int retryCount = 0, string retryHeader = "retry-number", bool useStringEventMessageType = false);

        void ExchangeDeclare(string exchange, string ExchangeType);
    }
}
