using ConnectionSql.Dtos.ProdutosDtos;
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
        
        public async Task<List<Produto>> BuscarPedidoCompleto()
        {
            try
            {
                var query = @"SELECT ID,
                                    NOME,
                                    VALOR,
                                    STATUS,
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

            string query = @"SELECT ID,
                                    NOME,
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
        public async Task<bool> AtualizarProduto(int id, Produto produto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id, DbType.Int32);
            param.Add("@Nome", produto.Nome, DbType.AnsiString);
            param.Add("@Valor", produto.Valor, DbType.Double);
            param.Add("@Status", produto.Status, DbType.Boolean);
            param.Add("@DataAlteracao", produto?.DataAlteracao, DbType.DateTime);
            param.Add("@QuantidadeEstoque", produto.QuantidadeEmEstoque, DbType.Int32);
            param.Add("@CategoriaID", produto.CategoriaId, DbType.Int32);

            var query = @"Update Produtos  
                        Set NOME = @Nome,
                            VALOR = @Valor,
                            STATUS = @Status,
                            DATAALTERACAO = @DataAlteracao,
                            QUANTIDADEEMESTOQUE = @QuantidadeEstoque
                             WHERE Produtos.ID = @ID";
                            
           var retorno = await ExecuteAsync(query, param, commandType: CommandType.Text);
            return retorno > 0;
        }

        public async Task<bool> AtualizarProdutoSimplificado(int id, Produto produto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id, DbType.Int32);
            param.Add("@Nome", produto.Nome, DbType.AnsiString);
            param.Add("@CategoriaID", produto.CategoriaId, DbType.Int32);
            param.Add("@DataAlteracao", produto.DataAlteracao, DbType.DateTime);

            var query = @"Update Produtos  
                        Set NOME = @Nome,
                        CategoriaID = @CategoriaID,
                        DataAlteracao = @DataAlteracao
                        WHERE Produtos.ID = @ID";

            var retorno = await ExecuteAsync(query, param, commandType: CommandType.Text);
            return retorno > 0;
        }

        public async Task<bool> DeleteProduto(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID",id, DbType.Int32);

            string query = @"DELETE FROM Produto 
                             WHERE Produto.Id = @ID";

            var retorno =  await ExecuteAsync(query, param, commandType: CommandType.Text);
            return retorno > 0;
        }

    }
}
