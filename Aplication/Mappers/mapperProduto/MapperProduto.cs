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
                DataCriacao = CreateprodutoDto.DataCriacao,
                DataAlteracao = CreateprodutoDto.DataAlteracao,
                QuantidadeEmEstoque = CreateprodutoDto.QuantidadeEmEstoque,
                Categoria = CreateprodutoDto.Categoria,
                CategoriaId = CreateprodutoDto.CategoriaId
            };
        }

        public static Produto UpdateParaProduto(UpdateProdutoDto updateProduto) 
        {
            return new Produto()
            {
                Categoria = updateProduto.Categoria,
                Nome = updateProduto.Nome,
                Valor = updateProduto.Valor,
                Status = updateProduto.Status,
                CategoriaId = updateProduto.CategoriaId,
                QuantidadeEmEstoque = updateProduto.QuantidadeEmEstoque,
                DataCriacao = updateProduto.DataCriacao,
                DataAlteracao = updateProduto.DataAlteracao
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
    }
}
