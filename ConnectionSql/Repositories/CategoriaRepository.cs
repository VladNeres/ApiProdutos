using AutoMapper.Configuration;
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
        
        public async Task<IEnumerable<Categoria>> BuscarTodasAscategorias()
        {
            try
            {
                string query = @"Select * From Categorias";
                return await QueryAsync<Categoria>(query, commandType: CommandType.Text);
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


        public async Task<Categoria> CriarCategoria(Categoria categoria)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Nome", categoria.Nome, DbType.String);
                param.Add("@DataCriacao", categoria.DataCriacao, DbType.DateTime);
                string query = @"Insert Into Categorias (Nome,DataCriacao) values (@Nome,@DataCriacao)";
                
               return  await QueryFirstOrDefaultAsync<Categoria>(query, param: param, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
