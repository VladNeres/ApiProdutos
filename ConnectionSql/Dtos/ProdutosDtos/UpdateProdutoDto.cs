using System.ComponentModel.DataAnnotations;

namespace ConnectionSql.Dtos.ProdutosDtos
{
    public class UpdateProdutoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int QuantidadeEmEstoque { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
