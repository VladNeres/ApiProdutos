namespace ServiceBus.Base
{
    public interface IPublisherBus
    {
        Task Publicar<T>(T message, string routingKey = null) where T : class;
    }
}
