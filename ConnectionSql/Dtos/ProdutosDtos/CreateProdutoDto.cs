using Domain.ViewlModels;
using System.ComponentModel.DataAnnotations;

namespace ConnectionSql.Dtos.ProdutosDtos;

public class CreateProdutoDto
{
    public CreateProdutoDto(string nome, double valor, int quantidadeEmEstoque, int categoriaId)
    {
        Nome = nome;
        Valor = valor;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        CategoriaId = categoriaId;
    }

    public CreateProdutoDto(string nome, double valor, bool status, int quantidadeEmEstoque, int categoriaId, Categoria categoria)
    {
        Nome = nome;
        Valor = valor;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        CategoriaId = categoriaId;
    }

    public CreateProdutoDto()
    {

    }

    [Required]
    public string Nome { get; set; }
    [Required]
    public double Valor { get; set; }
    [Required]
    public int QuantidadeEmEstoque { get; set; }
    [Required]
    public int CategoriaId { get; set; }



}
