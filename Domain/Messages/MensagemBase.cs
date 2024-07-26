namespace Domain.Messages
{
    public class MensagemBase<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }

        public MensagemBase(int statusCode, string message, T @object)
        {
            StatusCode = statusCode;
            Message = message;
            Object = @object;
        }

        public MensagemBase(int statusCode, T @object)
        {
            StatusCode = statusCode;
            Object = @object;
        }

        public MensagemBase()
        {

        }

    }
}
