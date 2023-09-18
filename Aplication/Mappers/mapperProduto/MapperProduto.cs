using ConnectionSql.Dtos.ProdutosDtos;
using Domain.ViewlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers.mapperProduto
{
    public static class MapperProduto
    {
        public static Produto CreateParaProduto(CreateProdutoDto CreateprodutoDto)
        {
            return new Produto ()
            {
                Nome = CreateprodutoDto.Nome,
                Valor = CreateprodutoDto.Valor,
                Status = CreateprodutoDto.Status,
                QuantidadeEmEstoque = CreateprodutoDto.QuantidadeEmEstoque,
                CategoriaId = CreateprodutoDto.CategoriaId,
                DataCriacao = DateTime.Now,
            };
        }

        public static Produto UpdateParaProduto(UpdateProdutoDto updateProduto) 
        {
            return new Produto()
            {
                Nome = updateProduto.Nome,
                Valor = updateProduto.Valor,
                Status = updateProduto.Status,
                CategoriaId = updateProduto.CategoriaId,
                QuantidadeEmEstoque = updateProduto.QuantidadeEmEstoque,
                DataAlteracao = DateTime.Now,
            };
        }

        public static ReadProdutoDto ParaReadProdutoDto (Produto produto)
        {
            return new ReadProdutoDto()
            {
                Nome = produto.Nome,
                Valor = produto.Valor,
                Status = produto.Status,
                DataCriacao = produto.DataCriacao,
                DataAlteracao = produto.DataAlteracao,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                Categoria = produto.Categoria,
                CategoriaId = produto.CategoriaId
            };
        }

        public static Produto UpdateSimplificadoParaProduto(UpdateProdutoSimplificado produtoSimplificado)
        {
            return new Produto()
            {
                Nome = produtoSimplificado.Nome,
                CategoriaId = produtoSimplificado.CategoriaID,
                DataAlteracao = DateTime.Now
            };
        }
    }
}
