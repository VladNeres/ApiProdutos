using Microsoft.Extensions.Configuration;

namespace ServiceBus
{
   public class PublisherConfiguration
   {
        public string HostName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
   }
}
