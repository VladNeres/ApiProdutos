using ConnectionSql.RepositopriesInterfaces;
using Dapper;
using Domain.ViewlModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSql.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(string connection) : base(connection) { }
        

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Nome", produto.Nome, DbType.AnsiString);
            param.Add("@Valor", produto.Valor, DbType.Double);
            param.Add("@Status", produto.Status, DbType.Boolean);
            param.Add("@DataCriacao", produto.DataCriacao, DbType.DateTime);
            param.Add("@DataAlteraca", produto?.DataAlteracao, DbType.DateTime);
            param.Add("@QuantidadeEstoque", produto.QuantidadeEmEstoque, DbType.Int32);
            param.Add("@CategoriaID", produto.CategoriaId, DbType.Int32);

            var query = @"Update Produtos  
                        Set NOME = @Nome
                            VALOR = @Valor
                            STATUS = @Status
                            DATACRIACAO = @DataCriacao 
                            DATAALTERACAO = @DataAlteracao
                            QUANTIDADEEMESTOQUE = @QuantidadeEstoque";
                            
            return await QuerySingleAsync<Produto>(query, param, commandType: CommandType.Text);
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Nome", produto.Nome, DbType.AnsiString);
            param.Add("@Valor", produto.Valor, DbType.Double);
            param.Add("@Status", produto.Status, DbType.Boolean);
            param.Add("@DataCriacao", produto.DataCriacao, DbType.DateTime);
            param.Add("@DataAlteraca", produto?.DataAlteracao, DbType.DateTime);
            param.Add("@QuantidadeEstoque", produto.QuantidadeEmEstoque, DbType.Int32);
            param.Add("@CategoriaID", produto.CategoriaId, DbType.Int32);

            var query = @"INSERT 
                         INTO produtos (NOME, VALOR, STATUS, DATACRIACAO, DATAALTERACAO, QUANTIDADEEMESTOQUE, CategoriaID)
                        VALUES (@Nome,Valor,@Status,@DataCriacao,@DataAlteracao, @QuantidadeEstoque, @CategoriaID)";

            return await  QuerySingleAsync<Produto>(query, param, commandType: CommandType.Text );
        }

        public async Task<List<Produto>> BuscarPedidoCompleto()
        {
            try
            {
                var query = @"SELECT 
                                    NOME,
                                    VALOR,
                                    STATUSPedido,
                                    DATACRIACAO,
                                    DATAALTERACAO,
                                    QUANTIDADEEMESTOQUE,
                                    CategoriaID
                              FROM Produtos";

                var respnse = await QueryAsync<Produto>(query, commandType: CommandType.Text);
                return respnse.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Produto> BuscarPorId(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id, DbType.Int32);

            string query = @"SELECT NOME,
                                    VALOR,
                                    STATUS,
                                    DATACRIACAO,
                                    DATAALTERACAO,
                                    QUANTIDADEEMESTOQUE,
                                    CategoriaID
                          FROM Produtos 
                          WHERE Id = @ID";

            return await QueryFirstOrDefaultAsync<Produto>(query, param: param, commandType: CommandType.Text);
            
        }
    }
}
