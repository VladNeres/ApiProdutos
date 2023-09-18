using Aplication.interfaces;
using Aplication.Services;
using Aplication.SeviceInterfaces;
using ConnectionSql.RepositopriesInterfaces;
using ConnectionSql.Repositories;

namespace SistemaDeMercado.DependencesInjections
{
    public class DependenceInjection
    {
        public static IServiceCollection InjectionDependence(IServiceCollection services , IConfiguration configuration)
        {

            //Singleton;
            //Aqui Eu passei a connection string na injeção da classe Repository, e la na BaseRepository ey passei uma string comum no construtor, e la na CategoriaRepository eu passo o IConfiguration pegando a connection string que esta na
            //    appsettings
            //===================================================================================================================================================================================================================
            services.AddSingleton<ICategoriaRepository, CategoriaRepository>(x => new CategoriaRepository(configuration["ConnectionStrings:MercadoConnection"]));
            services.AddSingleton<IProdutoRepository, ProdutoRepository>(x => new ProdutoRepository(configuration["ConnectionStrings:MercadoConnection"]));
            //===================================================================================================================================================================================================================



            //Outra forma de fazer a connectionCom o banco 
            //Para Utilizar esse formato é necessario instalar o packge (pomelo.EntityFrameWorkCore.MySql)
            /*=====================================================================================================================================================================================================================
              var connection = configuration.GetConnectionString("ConnectionString:MercadoConnection)
               services.AddDbContext<CategoriaRepository>(x => x.UseMySql(connection, ServerVersion.AutoDetect(connectionString)));
            =======================================================================================================================================================================================================================
             */


            //Scopped
            //services.AddScoped<ICategoriaRepository,CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            return services;
        }
    }
}
