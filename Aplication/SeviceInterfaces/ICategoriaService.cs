using ConnectionSql.Dtos;
using Domain.ViewlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.interfaces
{
    public interface ICategoriaService
    {
        Task CriarCategoria(Categoria categoriaDto);
    }
}
