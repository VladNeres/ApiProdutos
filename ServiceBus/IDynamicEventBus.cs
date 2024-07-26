namespace ServiceBus
{
    public interface IDynamicEventBus
    {
        void PublishDynamic(DynamicIntegrationEvent eventData, int retryCount = 0, string retryHeader = "retry-number", bool useStringAsEventMessageType = false);

        Task PublishDynamicAsync(DynamicIntegrationEvent eventData, int retryCount = 0, string retryHeader = "retry-number", bool useStringAsEventMessageType = false);

        void ExchangeDeclare(string exchange, string exchangeType);
    }
}
