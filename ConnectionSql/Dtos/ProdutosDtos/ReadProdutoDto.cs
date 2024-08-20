namespace ConnectionSql.Dtos.ProdutosDtos;

public class ReadProdutoDto
{
    public Guid CodigoProduto { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public bool Status { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public int CategoriaId { get; set; }
}
