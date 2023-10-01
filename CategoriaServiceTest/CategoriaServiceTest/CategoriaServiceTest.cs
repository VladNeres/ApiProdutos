using Aplication.Mappers;
using Aplication.Services;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using ConnectionSql.Repositories;
using Domain.Messages;
using NSubstitute;
using Teste.BaseMock;

namespace Teste.CategoriaServiceTest;

public class CategoriaServiceTest
{
    private readonly ICategoriaRepository _repository = Substitute.For<ICategoriaRepository>();
    private readonly CategoriaService _service;
    private readonly IDataTableToBulk _dataTableToBulk = Substitute.For<IDataTableToBulk>();
    public CategoriaServiceTest()
    {

        _service = new CategoriaService(_repository,_dataTableToBulk);
        
    }

    [Fact]
    public void Test1()
    {

    }

    [Fact]
    public async void BuscarTodasCategorias_Retornar_Categorias_Tiver_No_Banco()
    {
        //ARRANGE
        var lista = Mock.ListaDeCategorias();
        var listaRead = Mock.ListaReadCategoriaDto();
        _repository.BuscarTodasAscategorias().Returns(lista);
        
        //ACT
       var response =  await _service.BuscarTodasCategorias();

        //ASSERT
        Assert.Equal(200, response.StatusCode);


    }

    [Fact]
    public async void CriarCategoria_Nao_Existir_CriarCategoria_Retornar201()
    {
        //ARRANGE
        var categoriaDto = Mock.CreateCategoriaDto();

        var categoria = MapperCategoria.ParaCategoria(categoriaDto);
        await _repository.CriarCategoria(categoria);

        //ACT
        var response = await _service.CriarCategoria(categoriaDto);


        //ASSERT
        Assert.Equal(201, response.StatusCode);
    }

    [Fact]
    public async void AtualizarCategoria_SeExistirCategoria_Retornar204()
    {
        //ARRANGE
        var createCategoria = new UpdateCategoriaDto { Nome = "NomeInexistente"};
        int id = 1;
        var listCategoria = Mock.ListaDeCategorias();
         _repository.BuscarTodasAscategorias().Returns(listCategoria);

        //ACT
        var response = await _service.AtualizarCategoria(id, createCategoria);

        //ASSERT
        Assert.Equal(204, response.StatusCode);
    }


    [Fact]
    public async void DeletarCategoria_QuandoIDExistir_DeletarERetornar204()
    {
        //ARRANGE
        int id = 1;
        var categoria = Mock.ListaDeCategorias();
        _repository.BuscarCategoriasPorId(id).Returns(categoria);

        //ACT
        var response = await _service.DeletarCategoria(id);

        //ASSERT
        Assert.Equal(204, response.StatusCode);
    }

}