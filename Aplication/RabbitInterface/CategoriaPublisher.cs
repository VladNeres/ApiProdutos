using ApiProdutos.AMQP;
using Aplication.Services;
using ConnectionSql.Dtos;
namespace Domain.Messages
{
    public class CategoriaPublisher : ICategoriaPublisher
    {
        private readonly CategoriaService _categoriaService;
        public CategoriaPublisher(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public void SendMessage(CreateCategoriaDto categoria)
        {
            _categoriaService?.CriarCategoria(categoria);
        }
    }
}
