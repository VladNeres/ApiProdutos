using Aplication.interfaces;
using Aplication.Services;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using NSubstitute;
using NUnit.Framework;
using Xunit;

namespace Test
{
    public class CategoriaServiceTest
    {
        private ICategoriaService _service = Substitute.For<ICategoriaService>();
        private ICategoriaRepository _repository = Substitute.For<ICategoriaRepository>();

        public CategoriaServiceTest(ICategoriaRepository repository)
        {
            _repository = repository;
            _service = new CategoriaService(_repository);
        }


        [Fact]
        public void CreateCategoria_Quando_Nome_NaoExistir_Retornara_201()
        {
            //ARRange
            var categoriaDto = new CreateCategoriaDto { Nome = "Teste" };


           var response = _service.CriarCategoria(categoriaDto);

            //ASSERT
            Assert.Equals(201, response);

        }
    }
}