using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus
{
    public class DynamicIntegrationEvent
    {
        public DynamicIntegrationEvent(string message, string eventName, string exchange = "", string exchangeType = "topic")
        {
            EventName = eventName;
            Exchange = exchange;
            ExchangeType = exchangeType;
            Message = message;
        }

        public string EventName { get; private set; }
        public string Exchange { get; private set; }
        public string ExchangeType { get; private set; } = "topic";
        public string Message { get; private set; }
    }
}
