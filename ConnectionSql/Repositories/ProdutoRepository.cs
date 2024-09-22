using ConnectionSql.RepositopriesInterfaces;
using Dapper;
using Domain.Models;
using Domain.ViewlModels;
using System.Data;

using static Dapper.SqlMapper;

namespace ConnectionSql.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(string connection) : base(connection) { }




        public async Task<Paginacao<List<Produto>>> BuscarPedidoPaginada(int currentPge, int pageSize)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                int maxPagexSize = 50;
                pageSize = pageSize < maxPagexSize ? pageSize : maxPagexSize;

                int skip = (int)(currentPge - 1) * (int)pageSize;
                int take = (int)pageSize;

                dynamicParameters.Add("@Skip", skip, DbType.Int32);
                dynamicParameters.Add("@Take", take, DbType.Int32);

                var query = @" SELECT COUNT(*)
                               FROM Produtos

                                    SELECT 
                                    P.NOME,
                                    P.VALOR,
                                    P.STATUS,
                                    E.DATAEntrada,
                                    E.DATASaida,
                                    P.CategoriaID,
                                    P.CodigoProduto,
                                    E.Quantidade QuantidadeEmEstoque
                              FROM Produtos P
                              JOIN Estoque E ON E.CodigoProduto = CodigoProduto
							  Order By P.Nome
                              OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
                                ";
                if (skip < 0 && take == 0 || skip <= 0)
                {
                    query = query.Replace("Order By ID\r\n                              OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY", " ");
                }

                return await MultipleQueryAsync<Paginacao<List<Produto>>>(query, async (GridReader reader) =>
                {
                    int totalCount = reader.Read<int>().FirstOrDefault();
                    List<Produto> Produtos = reader.Read<Produto>().ToList();

                    return new Paginacao<List<Produto>>(totalCount, Produtos, currentPge, pageSize);
                }, dynamicParameters, commandType: CommandType.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Produto>> BuscarPedidoCompleto()
            {
            try
            {
                var query = @"       SELECT 
                                    P.CodigoProduto,
                                    P.NOME,
                                    P.VALOR,
                                    P.STATUS,
                                    E.DATAEntrada,
                                    E.DATASaida, 
                                    P.CategoriaID,
									E.Quantidade as QuantidadeEmEstoque
                              FROM Produtos AS P
							  Join Estoque as E
							   ON E.CodigoProduto = P.CodigoProduto
                                ";

                var response = await QueryAsync<Produto>(query, MapearObjetos, commandType: CommandType.Text);
                return response.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<Produto>> MapearObjetos(GridReader reader)
        {
            var listaDeFiltros = (await reader.ReadAsync<Produto>()).ToList();
            var categoria = await reader.ReadFirstOrDefaultAsync<Categoria>();

            return listaDeFiltros;
        }
        public async Task<Produto> BuscarPorId(Guid id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id, DbType.Guid);

            string query = @"SELECT P.CodigoProduto,
                                    P.NOME,
                                    P.VALOR,
                                    P.STATUS,
                                    E.DATAEntrada dataCriacao,
                                    E.DATASaida dataAlteracao,
                                    P.CategoriaID
                          FROM Produtos P
                          JOIN Estoque E ON E.CodigoProduto = P.CodigoProduto
                          WHERE P.CodigoProduto = @ID
                            
                            Select ID,NOME,DATACRIACAO, DATAALTERACAO
                                FROM Categorias";

            return await MultipleQueryAsync(query, async (GridReader reader) =>
            {
                var produto = await reader.ReadFirstOrDefaultAsync<Produto>();
                var categoria = await reader.ReadFirstOrDefaultAsync<Categoria>();
                return produto;
            }, param: param, commandType: CommandType.Text);

        }

        public async Task<int> CriarProduto(Produto produto)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CodigoProduto", produto.CodigoProduto, DbType.Guid);
                param.Add("@NomeProduto", produto.Nome, DbType.AnsiString);
                param.Add("@CategoriaID", produto.CategoriaId, DbType.Int32);
                param.Add("@Valor", produto.Valor, DbType.Decimal);
                param.Add("@Status", produto.Status, DbType.Boolean);
                param.Add("@DataCriacao", produto.DataEntrada, DbType.DateTime);

                var proc = @"INSERT INTO Produtos(CodigoProduto,Nome,Valor,DataCriacao,Status,CategoriaId)
                              VALUE (@CodigoProduto,@NomeProduto,@Valor,@DataCriacao,@Status,@CategoriaID)";

                return await ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> AtualizarProduto(Guid id, Produto produto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CodigoProduto", id, DbType.Guid);
            param.Add("@Nome", produto.Nome, DbType.AnsiString);
            param.Add("@Valor", produto.Valor, DbType.Double);
            param.Add("@Status", produto.Status, DbType.Boolean);
            param.Add("@DataAlteracao", produto?.DataSaida, DbType.DateTime);
            param.Add("@CategoriaID", produto.CategoriaId, DbType.Int32);

            var query = @"AlterarProduto";

            var retorno = await ExecuteAsync(query, param, commandType: CommandType.Text);
            return retorno > 0;
        }

        public async Task<bool> AtualizarProdutoSimplificado(Guid codigoDoProduto, Produto produto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CodigoProduto", codigoDoProduto, DbType.Guid);
            param.Add("@Nome", produto.Nome, DbType.AnsiString);
            param.Add("@CategoriaID", produto.CategoriaId, DbType.Int32);
            param.Add("@DataAlteracao", produto.DataSaida, DbType.DateTime);

            var query = @"Update Produtos  
                        Set NOME = @Nome,
                        CategoriaID = @CategoriaID,
                        DataAlteracao = @DataAlteracao
                        WHERE Produtos.CodigoProduto = @CodigoProduto";

            var retorno = await ExecuteAsync(query, param, commandType: CommandType.Text);
            return retorno > 0;
        }

        public async Task<bool> DeleteProduto(Guid id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id, DbType.Guid);

            string procedure = @"DeleteProduto";

            var retorno = await ExecuteAsync(procedure, param, commandType: CommandType.StoredProcedure);
            return retorno > 0;
        }

    }
}
