using AutoMapper.Configuration;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using Dapper;
using Domain.ViewlModels;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConnectionSql.Repositories
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        //outra forma de pegar connection public CategoriaRepository(IConfiguration configuration) : base (configuration.GetConnectionString("MercadoConnection")
        public CategoriaRepository( string connection) : base(connection) 
        {
        }
        
        public async Task<List<Categoria>> BuscarTodasAscategorias()
        {
            try
            {
                string query = @"Select * From Categorias";
                var retorno = await QueryAsync<Categoria>(query, commandType: CommandType.Text);
                return retorno.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Categoria> BuscarCategoriasPorId(int id)
        {
            try
            {
                DynamicParameters param  = new DynamicParameters();
                param.Add("@ID", id, DbType.Int32);

                string query = @"Select * From Categorias Where ID = @ID";
                
                return await QueryFirstOrDefaultAsync<Categoria>(query, param:param, commandType: CommandType.Text);
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
                
            string query = @"Select * From Categorias Where Nome = @Nome";

                var retorno = await QueryFirstOrDefaultAsync<bool>(query,param: prameters, commandType: CommandType.Text);
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
                
               return  await ExecuteAsync(query, param: param, CommandType.Text);
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
                return await ExecuteAsync(query,param, CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeletarCategoria(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id, DbType.Int32);

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
