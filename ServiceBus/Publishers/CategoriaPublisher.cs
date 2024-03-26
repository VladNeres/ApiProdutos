using Microsoft.Extensions.Options;
using ServiceBus;
using ServiceBus.Base;
using ServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messages
{
    public class CategoriaPublisher : MessageQueue, ICategoriaPublisher
    {
        public CategoriaPublisher(IDynamicEventBus dynamicEventBus,  IOptions<RabbitEventBusSettings> eventBusSettingsOptions = null
            )
            : base(dynamicEventBus, eventBusSettingsOptions.Value.GetPublisherConfiguration(""))
        {
        }

        public async Task Publicar<T>(T message, string routignKey = null) where T : class
        {
			try
			{
				await PublishAsync(message, routignKey);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
