using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain.ViewlModels;

public class Produto
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public bool Status { get; set; }
    public int  QuantidadeEmEstoque { get; set; }
    public int CategoriaId { get; set; }
    public  Categoria Categoria { get; set; }
    public string CodigoDoPedido { get; set; } 
    
    public Produto()
    {
        
    }

    public Produto(int iD, string nome, double valor, DateTime dataCriacao, DateTime dataAlteracao, bool status, int quantidadeEmEstoque, int categoriaId, string codigoDoPedido)
    {
        ID = iD;
        Nome = nome;
        Valor = valor;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;
        Status = status;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        CategoriaId = categoriaId;
        CodigoDoPedido = codigoDoPedido;
    }
}
