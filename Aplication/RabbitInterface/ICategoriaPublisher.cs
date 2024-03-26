using ConnectionSql.Dtos;
using Domain.ViewlModels;

namespace ApiProdutos.AMQP
{
    public interface ICategoriaPublisher
    {
        void SendMessage(CreateCategoriaDto categoria);

    }
}
