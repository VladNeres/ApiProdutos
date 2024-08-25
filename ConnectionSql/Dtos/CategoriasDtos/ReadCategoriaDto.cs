

using ConnectionSql.Dtos.ProdutosDtos;

namespace ConnectionSql.Dtos
{
    public class ReadCategoriaDto
    {
        public ReadCategoriaDto(int id, string nome, DateTime dataCriacao, DateTime? dataAlteracao, List<ReadProdutoDto> produtos)
        {
            Id = id;
            Nome = nome;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            Produtos = produtos;
        }

        public int Id { get; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; } = null;
        public List<ReadProdutoDto> Produtos { get; set; }
    }
}
