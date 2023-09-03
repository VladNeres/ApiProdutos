using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.interfaces;
using Aplication.Mappers;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using Domain.ViewlModels;

namespace Aplication.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Categoria>> BuscarTodasCategorias()
        {
            return await _repository.BuscarTodasAscategorias();
        }

        public async Task CriarCategoria(Categoria categoriaDto)
        {
            var response =  _repository.CriarCategoria(categoriaDto);
            
        }
    }
}
