namespace ConnectionSql.Dtos.ProdutosDtos
{
    public class UpdateProdutoSimplificado
    {
        public string Nome { get; set; }
        public Guid CodigoProduto { get; set; }
        public int CategoriaID { get; set; }
    }
}
