using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain.ViewlModels;

public class Produto
{
    public string Nome { get; set; }
    public double Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
    public bool Status { get; set; }
    public int CategoriaId { get; set; }
    public Guid CodigoDoProduto { get; set; }
    public int QuantidadeEmEstoque { get; set; }

    public Produto()
    {
        
    }

    public Produto( string nome, double valor, DateTime dataCriacao, DateTime dataAlteracao, bool status,  int categoriaId, Guid codigoDoPedido)
    {
        Nome = nome;
        Valor = valor;
        DataEntrada = dataCriacao;
        DataSaida = dataAlteracao;
        Status = status;
        CategoriaId = categoriaId;
        CodigoDoProduto = codigoDoPedido;
    }
}
