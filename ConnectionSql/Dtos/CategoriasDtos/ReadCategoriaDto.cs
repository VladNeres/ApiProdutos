

using ConnectionSql.Dtos.ProdutosDtos;

namespace ConnectionSql.Dtos
{
    public class ReadCategoriaDto
    {
        public ReadCategoriaDto(string nome, DateTime dataCriacao, DateTime? dataAlteracao, List<ReadProdutoDto> produtos)
        {
            Nome = nome;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            Produtos = produtos;
        }

        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; } = null;
        public List<ReadProdutoDto> Produtos { get; set; }
    }
}
