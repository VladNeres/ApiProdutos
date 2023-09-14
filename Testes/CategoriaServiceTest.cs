using Aplication.interfaces;
using Aplication.Mappers;
using Aplication.Services;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using NSubstitute;
using Xunit;

namespace Testes
{
    public class CategoriaServiceTest
    {

        private readonly ICategoriaService _service = Substitute.For<ICategoriaService>();
        private readonly ICategoriaRepository _repository = Substitute.For<ICategoriaRepository>();

        public CategoriaServiceTest(ICategoriaRepository repository)
        {
            _repository = repository;
            _service = new CategoriaService(repository);
        }

        [Fact]
        public void Test()
        {

        }

        [Fact]
        public async void Quando_Nome_Nao_Existir_CriarCategoria_Retornar200()
        {
            var categoriaDto = new CreateCategoriaDto() { Nome = "teste" };

            var categoria= MapperCategoria.ParaCategoria(categoriaDto);
             await  _repository.CriarCategoria(categoria);

            var response  = await _service.CriarCategoria(categoriaDto);

            Assert.Equal(200, response.StatusCode);
        }
    }
}