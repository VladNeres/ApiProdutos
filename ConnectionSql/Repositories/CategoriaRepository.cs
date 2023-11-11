using ConnectionSql.RepositopriesInterfaces;
using Dapper;
using Domain.ViewlModels;
using System.Data;
using static Dapper.SqlMapper;

namespace ConnectionSql.Repositories
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        //outra forma de pegar connection public CategoriaRepository(IConfiguration configuration) : base (configuration.GetConnectionString("MercadoConnection")
        public CategoriaRepository(string connection) : base(connection)
        {
        }

        public async Task<List<Categoria>> BuscarTodasAscategorias()
        {
            try
            {
                string query = @"Select id,
                                        Nome,
                                        DataCriacao,
                                        DataAlteracao
                                 From Categorias
                                              
                                   SELECT P.ID,
                                          P.Nome,
                                          P.Valor, 
                                          P.DataCriacao, 
                                          P.DataAlteracao,
                                          P.Status, 
                                          P.CodigoDoProduto,
                                          P.CategoriaId,
                                          E.Quantidade As QuantidadeEmEstoque
                                    FROM Produtos AS P
                                    JOIN Estoque AS E 
                                    ON E.Produto_ID = P.ID";
                return await MultipleQueryAsync(query, async (GridReader reader) =>
                {
                    var listaDeCategorias = (await reader.ReadAsync<Categoria>()).ToList();
                    var listaDeProdutos = (await reader.ReadAsync<Produto>()).ToList();

                    listaDeCategorias.ForEach(c =>
                    {
                        if (c != null)
                            c.Produtos = listaDeProdutos.Where( p => c.ID == p.CategoriaId).ToList();
                    });

                    return listaDeCategorias;
                }, commandType: CommandType.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Categoria>> BuscarCategoriasPorId(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id, DbType.Int32);

                string query = @"Select ID,    
                                        Nome,
                                        DataCriacao,
                                        DataAlteracao 
                                From Categorias
                                Where ID = @ID
                                    
                                Select 
                                      Nome,Valor, DataCriacao, DataAlteracao,Status, CategoriaId, CodigoDoProduto
                                From Produtos";

                return await MultipleQueryAsync(query, async (GridReader reader) =>
                {
                    var categoria = (await reader.ReadAsync<Categoria>()).ToList();
                    var produtos = (await reader.ReadAsync<Produto>()).ToList();

                    categoria.ForEach(c =>
                    {
                        if (c != null)
                            c.Produtos = produtos.Where(p => c.ID == p.CategoriaId).ToList();
                    });

                    return categoria;
                },param, commandType: CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VerificarSeExisteCategoria(string nome)
        {
            DynamicParameters prameters = new DynamicParameters();
            prameters.Add("@Nome", nome, DbType.AnsiString);

            string query = @"Select 
                                        Nome,
                                        DataCriacao,
                                        DataAlteracao
                              From Categorias Where Nome = @Nome";

            var retorno = await QueryFirstOrDefaultAsync<bool>(query, param: prameters, commandType: CommandType.Text);
            return retorno;
        }



        public async Task<int> CriarCategoria(Categoria categoria)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Nome", categoria.Nome, DbType.String);
                param.Add("@DataCriacao", categoria.DataCriacao, DbType.DateTime);

                string query = @"Insert Into Categorias (Nome,DataCriacao) values (@Nome,@DataCriacao)";

                return await ExecuteAsync(query, param: param, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AtualizarCategoria(int id, Categoria categoria)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id, DbType.Int16);
                param.Add("@Nome", categoria.Nome, DbType.AnsiString);
                string query = "AlterarCategoria";
                return await ExecuteAsync(query, param, CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeletarCategoria(int categoriaId)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", categoriaId, DbType.Int32);

                string query = @"Delete  From Categorias WHERE ID = @Id";

                return await ExecuteAsync(query, param, CommandType.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
