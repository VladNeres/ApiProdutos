using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus
{
    public class DynamicIntegrationEvent
    {
        public DynamicIntegrationEvent(string eventName, string exchange, string message = "",  string exchangeType = "topic")
        {
            EventName = eventName;
            Exchange = exchange;
            ExchangeType = exchangeType;
            Message = message;
        }

        public string EventName { get; set; }
        public string Exchange { get; set; }
        public string ExchangeType { get; set; } = "topic";
        public string Message { get; set; }
    }
}
