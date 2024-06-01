using Aplication.ItemServiceHttpClient;
using Aplication.Services;
using Aplication.SeviceInterfaces;
using ConnectionSql.Dtos.ProdutosDtos;
using ConnectionSql.RepositopriesInterfaces;
using ConnectionSql.Repositories;
using Domain.Models;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Teste.BaseMock;
using Xunit;

namespace Teste.ProdutoServiceTest
{
    public class ProdutoServiceTest
    {
        private readonly IProdutoRepository _produtoRespository = Substitute.For<IProdutoRepository>();
        private readonly IDataTableToBulk _dataTableToBulk = Substitute.For<IDataTableToBulk>();
        private readonly IProdutoService _produtoService = Substitute.For<IProdutoService>();
        private readonly IEstoqueService _estoque = Substitute.For<IEstoqueService>();
        public ProdutoServiceTest()
        {
            _produtoService = new ProdutoService(_produtoRespository, _dataTableToBulk, _estoque);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        public async Task BuscarPedidoPaginado_Quando_BuscarPaginado_Ou_SemPaginacao_Retornar_200(int paginaAtual, int QuantidadePorPagina)
        {
            //ASSERT
            var produto = MockProduto.GerarListaDeProdutos();
            var paginacao = new Paginacao<List<Produto>>(2, produto, 1, 2);
            _produtoRespository.BuscarPedidoPaginada(paginaAtual, QuantidadePorPagina).Returns(paginacao);


            //ACT
            var response = await _produtoService.BuscarPedidosPaginada(paginaAtual, QuantidadePorPagina);


            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
        }

        [Fact]
        public async Task BuscarPedidoPaginado_Quando_BuscarPaginacao_NaoTiverProdutos_Retornar_204()
        {
            //ASSERT
            var produto = new List<Produto>() { };
            var paginacao = new Paginacao<List<Produto>>(2, produto, 1, 2);
            _produtoRespository.BuscarPedidoPaginada(Arg.Any<int>(), Arg.Any<int>()).Returns(paginacao);


            //ACT
            var response = await _produtoService.BuscarPedidosPaginada(1, 1);

            //ASSERT
            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);
        }

        [Fact]
        public async Task BuscarPedido_Retornar_200()
        {
            var produto = MockProduto.GerarListaDeProdutos();
            _produtoRespository.BuscarPedidoCompleto().Returns(produto);

            var response = await _produtoService.BuscarPedidos();

            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
        }

        [Fact]
        public async Task BuscarPedido_Retornar_204()
        {
            var produto = new List<Produto>() { };
            _produtoRespository.BuscarPedidoCompleto().Returns(produto);

            var response = await _produtoService.BuscarPedidos();

            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);
            Assert.Contains("Lista vazia", response.Message);
        }

        [Fact]
        public async Task CriarProduto_Retornar201()
        {
            //ARRENG
            var produto = MockProduto.GerarListaDeProdutos();
            var createProduto = MockProduto.CreateProdutoDto();
            _produtoRespository.BuscarPedidoCompleto().Returns(produto);

            //ACT
            var response = await _produtoService.CriarProduto(createProduto);

            //ASSERT
            Assert.Equal(StatusCodes.Status201Created, response.StatusCode);
            _produtoRespository.Received(1).BuscarPedidoCompleto();
            _produtoRespository.Received(1).CriarProduto(Arg.Any<Produto>(), createProduto.QuantidadeEmEstoque);

        }

        [Fact]
        public async Task CriarProduto_SeProduto_Ja_Existe()
        {
            //ARRENG
            var produto = MockProduto.GerarListaDeProdutos();
            var createProduto = new CreateProdutoDto() { Nome = "ProdutoTeste" };
            _produtoRespository.BuscarPedidoCompleto().Returns(produto);

            //ACT
            var response = await _produtoService.CriarProduto(createProduto);

            //ASSERT
            Assert.Equal(StatusCodes.Status422UnprocessableEntity, response.StatusCode);
            await _produtoRespository.Received(1).BuscarPedidoCompleto();
            await _produtoRespository.Received(0).CriarProduto(Arg.Any<Produto>(), createProduto.QuantidadeEmEstoque);

        }

        [Fact]
        public async Task AtualizarProduto_SeNomeProduto_Ja_Existe_Retornar_400()
        {
            var produto = MockProduto.GerarListaDeProdutos();
            var updateProduto = new UpdateProdutoDto() { Nome = "ProdutoTeste" };
            _produtoRespository.BuscarPedidoCompleto().Returns(produto);


            var response = await _produtoService.AtualizarPedido(Arg.Any<Guid>(), updateProduto);

            Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
            Assert.Contains("O produto ja existe", response.Message);
        }

        [Fact]
        public async Task AtualizarProduto_SeProduto_Nao_Exists_Retornar_400()
        {
            var produto = MockProduto.GerarListaDeProdutos();
            var updateProduto = new UpdateProdutoDto() { Nome = "Produto" };
            _produtoRespository.BuscarPedidoCompleto().Returns(produto);


            var response = await _produtoService.AtualizarPedido(Guid.NewGuid(), updateProduto);

            Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
            Assert.Contains("O produto não foi encontrado", response.Message);
        }

        [Fact]
        public async Task AtualizarProduto_Se_Nome_Produto_Nao_Exists_Retornar_201()
        {
            var produto = MockProduto.GerarListaDeProdutos();
            var updateProduto = new UpdateProdutoDto() { Nome = "Produto" };
            _produtoRespository.BuscarPedidoCompleto().Returns(produto);


            var response = await _produtoService.AtualizarPedido(Guid.Parse("CA32D422-50FB-4964-8C87-061362A2D834"), updateProduto);

            Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);
            Assert.Contains("Produto atualizado com sucesso!", response.Message);
        }


        [Theory]
        [InlineData("6994C146-95DB-4216-B421-05DA934BB682")]
        [InlineData("CA32D422-50FB-4964-8C87-061362A2D834")]
        public async Task Delete_Quando_Produto_Nao_Encontrado_OuCasoDeErro(Guid id)
        {
            var produto = MockProduto.ProdutoCompleto();
            _produtoRespository.BuscarPorId(id);
            _produtoRespository.DeleteProduto(id).Returns(true);
            var response = await _produtoService.DeletarProduto(id);


            _produtoRespository.BuscarPorId(id).Returns(produto);
            _produtoRespository.DeleteProduto(id).Returns(false);
            var response2 = await _produtoService.DeletarProduto(id);


            Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
            Assert.Contains("Produto não encontrado", response.Message);
            Assert.Equal(StatusCodes.Status400BadRequest, response2.StatusCode);
            Assert.Equal("Algo deu errado! produto não removido", response2.Message);
        }

        [Fact]
        public async Task Delete_Quando_Produto_Encontrado()
        {
            var produto = MockProduto.ProdutoCompleto();
             _produtoRespository.BuscarPorId(Arg.Any<Guid>()).Returns(produto);
            _produtoRespository.DeleteProduto(Arg.Any<Guid>()).Returns(true);
           
            
            var response = await _produtoService.DeletarProduto(Guid.NewGuid());


            Assert.Equal(StatusCodes.Status204NoContent, response.StatusCode);
            Assert.Contains("Produto deletado com sucesso", response.Message);
        } 
    }
}
