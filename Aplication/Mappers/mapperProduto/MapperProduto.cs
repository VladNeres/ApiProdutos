using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Models;
using Domain.ViewlModels;

namespace Aplication.Mappers.mapperProduto
{
    public static class MapperProduto
    {
        public static Produto ParaProduto(this CreateProdutoDto CreateprodutoDto)
        {
            return new Produto()
            {
                Nome = CreateprodutoDto.Nome,
                Valor = CreateprodutoDto.Valor,
                Status = true,
                CategoriaId = CreateprodutoDto.CategoriaId,
                DataEntrada = DateTime.Now,
                CodigoProduto = Guid.NewGuid(),

            };
        }

        public static Produto UpdateParaProduto(this UpdateProdutoDto updateProduto)
        {
            return new Produto()
            {
                Nome = updateProduto.Nome,
                Valor = updateProduto.Valor,
                Status = updateProduto.Status,
                CategoriaId = updateProduto.CategoriaId,
                DataSaida = DateTime.Now,
            };
        }

        public static ReadProdutoDto ParaReadProdutoDto(this Produto produto)
        {
            return new ReadProdutoDto()
            {
                CodigoProduto = produto.CodigoProduto,
                Nome = produto.Nome,
                Valor = produto.Valor,
                Status = produto.Status,
                DataCriacao = produto.DataEntrada,
                DataAlteracao = produto.DataSaida,
                CategoriaId = produto.CategoriaId,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque
            };
        }

        public static Produto UpdateSimplificadoParaProduto(this UpdateProdutoSimplificado produtoSimplificado)
        {
            return new Produto()
            {
                Nome = produtoSimplificado.Nome,
                CategoriaId = produtoSimplificado.CategoriaID,
                DataSaida = DateTime.Now
            };
        }

        public static Paginacao<List<ReadProdutoDto>> ParaPaginacao(Paginacao<List<Produto>> paginacao)
        {
            var produtosConvertidos = paginacao.Data.Select(p => ParaReadProdutoDto(p)).ToList();
            return new Paginacao<List<ReadProdutoDto>>(paginacao.TotalCount, produtosConvertidos, paginacao.CurrentPageNumber, paginacao.TotalPages)
            {
            };
        }
        public static ProdutoType PraraProdutoType(this Produto produto)
        {
            return new ProdutoType(produto.CodigoProduto)
            {
                CodigoDoPedido = produto.CodigoProduto
            };
        }

        public static List<ReadProdutoDto> ParaListReadProdutoDto(this List<Produto> produtos)
        {
            List<ReadProdutoDto> listaRead = new List<ReadProdutoDto>();
            foreach (var p in produtos)
            {
                listaRead.Add(p.ParaReadProdutoDto());
            }
            return listaRead;
        }


    }
}
