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
        public CategoriaRepository(/*IConfiguration configuration*/ string connection) : base(connection/*configuration.GetConnectionString("MercadoConnection")*/) 
        {
        }
        
        public async Task<IEnumerable<Categoria>> BuscarTodasAscategorias()
        {
            string query = @"Select * From Categorias";

            return await QueryAsync<Categoria>(query, commandType: CommandType.Text);
        }

        public async Task<int> CriarCategoria(Categoria categoria)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Nome", categoria.Nome, DbType.String);
                string query = @"Insert Into Categorias (Nome) values (@Nome)";
                
               return  await ExecuteAsync(query, param: param, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
