using Aplication.interfaces;
using Aplication.Mappers;
using Aplication.Services;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using ConnectionSql.Repositories;
using Domain.Messages;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Teste.BaseMock;
using Xunit;

namespace Teste.CategoriaServiceTest;

public class CategoriaServiceTest
{
    private readonly ICategoriaRepository _repository = Substitute.For<ICategoriaRepository>();
    private readonly ICategoriaService _service = Substitute.For<ICategoriaService>();
    private readonly IDataTableToBulk _dataTableToBulk = Substitute.For<IDataTableToBulk>();
    public CategoriaServiceTest()
    {

        _service = new CategoriaService(_repository,_dataTableToBulk);
        
    }

  
    [Fact]
    public async Task BuscarTodasCategorias_Quando_Tiver_Categorias_No_Banco_Retornar_200()
    {
        //ARRANGE
        var lista = MockCategoria.ListaDeCategorias();
        _repository.BuscarTodasAscategorias().Returns(lista);
        
        //ACT
       var response =  await _service.BuscarTodasCategorias();

        //ASSERT
        Assert.Equal(200, response.StatusCode);
        _repository.Received(1).BuscarTodasAscategorias();
    }

    [Fact]
    public async Task BuscarTodasCategorias_Quando_Tiver_Categorias_No_Banco_Retornar_204()
    {
        //ARRANGE
        var lista = new List<Categoria>();
        _repository.BuscarTodasAscategorias().Returns(lista);

        //ACT
        var response = await _service.BuscarTodasCategorias();

        //ASSERT

        Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);
        Assert.Contains("A lista esta vazia", response.Message);
        await _repository.Received(1).BuscarTodasAscategorias();

    }

    [Fact]
    public async void CriarCategoria_Se_Nao_Existir_CriarCategoria_Retornar201()
    {
        //ARRANGE
        var categoria = MockCategoria.CategoriaCompleta();
        var categoriaDto = MockCategoria.CreateCategoriaDto();
        await _repository.CriarCategoria(categoria);

        //ACT
        var response = await _service.CriarCategoria(categoriaDto);


        //ASSERT
        Assert.Equal(201, response.StatusCode);
        Assert.Contains("Categoria criada com sucesso", response.Message);
        _repository.Received(1).VerificarSeExisteCategoria(categoriaDto.Nome);
        _repository.Received(1).CriarCategoria(categoria);
    }

    [Fact]
    public async Task CriarCategoria_Se_Existir_CriarCategoria_Retornar204()
    {
        //ARRANGE
        var categoria = MockCategoria.CategoriaCompleta();
        var categoriaDto = MockCategoria.CreateCategoriaDto();
         _repository.CriarCategoria(categoria);
         _repository.VerificarSeExisteCategoria(categoria.Nome).Returns(true);
        //ACT
        var response = await _service.CriarCategoria(categoriaDto);
        Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);
        Assert.Contains("A categoria ja existe", response.Message);
    }

    [Fact]
    public async void AtualizarCategoria_SeExistirCategoria_Retornar204()
    {
        //ARRANGE
        var createCategoria = new UpdateCategoriaDto { Nome = "NomeInexistente"};
        int id = 1;
        var listCategoria = MockCategoria.ListaDeCategorias();
         _repository.BuscarTodasAscategorias().Returns(listCategoria);

        //ACT
        var response = await _service.AtualizarCategoria(id, createCategoria);

        //ASSERT
        Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);
    }

    [Fact]
    public async void AtualizarCategoria_SeExistirCategoria_Retornar400()
    {
        //ARRANGE
        var createCategoria = new UpdateCategoriaDto { Nome = "NomeInexistente" };
        int id = 1;
        var listCategoria = MockCategoria.ListaDeCategorias();
        _repository.BuscarTodasAscategorias().Returns(listCategoria);

        //ACT
        var response = await _service.AtualizarCategoria(id, createCategoria);

        //ASSERT
        Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
        Assert.Equal("categoria nula já existe uma categoria com esse nome", response.Message);

    }

    [Fact]
    public async void DeletarCategoria_QuandoIDExistir_DeletarERetornar204()
    {
        //ARRANGE
        int id = 1;
        var categoria = MockCategoria.ListaDeCategorias();
        _repository.BuscarCategoriasPorId(id).Returns(categoria);

        //ACT
        var response = await _service.DeletarCategoria(id);

        //ASSERT
        Assert.Equal(204, response.StatusCode);
    }

}