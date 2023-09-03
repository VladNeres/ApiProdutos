using Domain.ViewlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSql.RepositopriesInterfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarTodasAscategorias();
        Task<int> CriarCategoria(Categoria categoria);
    }
}
