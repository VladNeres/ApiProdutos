namespace ConnectionSql.Dtos.ProdutosDtos
{
    public class UpdateProdutoSimplificado
    {
        public string Nome { get; set; }
        public Guid CodigoDoProduto { get; set; }
        public int CategoriaID { get; set; }
    }
}
