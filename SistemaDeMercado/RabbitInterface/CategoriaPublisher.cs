using Domain.ViewlModels;

namespace ApiProdutos.AMQP
{
    public interface ICategoriaPublisher
    {
        void SendMessage(Categoria categoria);

    }
}
