using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Models;
using Domain.ViewlModels;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers.mapperProduto
{
    public static class MapperProduto
    {
        public static Produto CreateParaProduto(this CreateProdutoDto CreateprodutoDto)
        {
            return new Produto()
            {
                Nome = CreateprodutoDto.Nome,
                Valor = CreateprodutoDto.Valor,
                Status = CreateprodutoDto.Status,
                CategoriaId = CreateprodutoDto.CategoriaId,
                DataCriacao = DateTime.Now,
                CodigoDoProduto = Guid.NewGuid().ToString(),
              
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
                DataAlteracao = DateTime.Now,
            };
        }

        public static ReadProdutoDto ParaReadProdutoDto(this Produto produto)
        {
            return new ReadProdutoDto()
            {
                Nome = produto.Nome,
                Valor = produto.Valor,
                Status = produto.Status,
                DataCriacao = produto.DataCriacao,
                DataAlteracao = produto.DataAlteracao,
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
                DataAlteracao = DateTime.Now
            };
        }

        public static Paginacao<List<ReadProdutoDto>>ParaPaginacao(Paginacao<List<Produto>> paginacao)
        {
            var produtosConvertidos = paginacao.Data.Select(p => ParaReadProdutoDto(p)).ToList();
            return new Paginacao<List<ReadProdutoDto>>(paginacao.TotalCount, produtosConvertidos,paginacao.CurrentPageNumber,paginacao.TotalPages)
            {
            };
        }
        public static ProdutoType PraraProdutoType(this Produto produto)
        {
            return new ProdutoType(produto.CodigoDoProduto)
            {
                CodigoDoPedido = produto.CodigoDoProduto
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
