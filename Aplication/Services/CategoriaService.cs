using Aplication.interfaces;
using Aplication.Mappers;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using Domain.ViewlModels;
using Newtonsoft.Json;

namespace Aplication.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReadCategoriaDto>> BuscarTodasCategorias()
        {
            var buascarTodasCategorias = await _repository.BuscarTodasAscategorias();
            if(buascarTodasCategorias.Count() > 0 || buascarTodasCategorias.Any())
            {
               var response =  MapperCategoria.ParaListaReadCategoriaDto(buascarTodasCategorias);
               return response;
            }
            return null;
        }

        public async Task<ReadCategoriaDto> BuscarCategoriasPorId(int id)
        {
            var buascarTodasCategorias = await _repository.BuscarCategoriasPorId(id);
            if (buascarTodasCategorias != null)
            {
                try
                {
                    var response =  MapperCategoria.ParaReadCategoriaDto(buascarTodasCategorias);
                    return response;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return null;
        }
        public async Task<Categoria> CriarCategoria(CreateCategoriaDto categoriaDto)
        {
            try
            {
                   Categoria categoria = MapperCategoria.ParaCategoria(categoriaDto);
                Task<Categoria> response =  _repository.CriarCategoria(categoria);
                
                if (!response.IsCompleted)
                    throw response.Exception;
                   
                return await response;
           

            }
            catch (Exception)
            {

                throw;
            }
           
            
        }
    }
}
