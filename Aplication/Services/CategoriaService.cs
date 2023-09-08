using Aplication.interfaces;
using Aplication.Mappers;
using ConnectionSql.Dtos;
using ConnectionSql.RepositopriesInterfaces;
using Domain.Messages;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Http;

namespace Aplication.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<MensagemBase<IEnumerable<ReadCategoriaDto>>> BuscarTodasCategorias()
        {
            var buascarTodasCategorias = await _repository.BuscarTodasAscategorias();
            if(buascarTodasCategorias.Count() > 0 || buascarTodasCategorias.Any())
            {
               var response =  MapperCategoria.ParaListaReadCategoriaDto(buascarTodasCategorias);
                return new MensagemBase<IEnumerable<ReadCategoriaDto>>()
                {
                    StatusCode = 200,
                    Object = response
               };
            }
            return new MensagemBase<IEnumerable<ReadCategoriaDto>>()
            {
                Message = "A lista esta vazia",
                StatusCode = StatusCodes.Status204NoContent,
                Object = null
            };
        }

        public async Task<MensagemBase<ReadCategoriaDto>> BuscarCategoriasPorId(int id)
        {
            try
            {
                var buascarTodasCategorias = await _repository.BuscarCategoriasPorId(id);
                if (buascarTodasCategorias != null)
                {
                        var response =  MapperCategoria.ParaReadCategoriaDto(buascarTodasCategorias);
                        return new MensagemBase<ReadCategoriaDto>()
                        {
                            Object = response,
                            StatusCode = StatusCodes.Status204NoContent,
                        };

                }
                return new MensagemBase<ReadCategoriaDto>()
                {
                    Message = "categoria não encontrada",
                    Object = null,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task <MensagemBase<Categoria>> CriarCategoria(CreateCategoriaDto categoriaDto)
        {
            try
            {
               var buscaCategorias = await _repository.VerificarSeExisteCategoria(categoriaDto.Nome);
               

                if (buscaCategorias)
                    return new MensagemBase<Categoria>()
                    {
                        Message = "A categoria ja existe",
                        Object = null,
                        StatusCode = StatusCodes.Status204NoContent
                    };

                Categoria categoria = MapperCategoria.ParaCategoria(categoriaDto);
               var response = await _repository.CriarCategoria(categoria);

                return new MensagemBase<Categoria>()
                {
                    Message = "Categoria criada com sucesso",
                    StatusCode = StatusCodes.Status201Created
                };
           

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MensagemBase<UpdateCategoriaDto>> AtualizarCategoriaCompleta(int id, UpdateCategoriaDto updateCategoria)
        {
           List<Categoria> categoriaDto = await _repository.BuscarTodasAscategorias();
            Categoria categoria = MapperCategoria.DeUpdateCategoriaDtoParaCategoria(updateCategoria);
            if (categoriaDto.FirstOrDefault(c => c.ID == id) == null) 
            return new MensagemBase<UpdateCategoriaDto>()
            {
                Message = "Categoria não encontrada",
                Object = null,
                StatusCode = StatusCodes.Status204NoContent
            };

            
            if(updateCategoria == null || categoriaDto.Any(c => c.Nome.Equals(updateCategoria.Nome)))
            {
                return new MensagemBase<UpdateCategoriaDto>()
                {
                    Message = "categoria nula já existe uma categoria com esse nome",
                    Object = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

           int Atualizar =  await _repository.AtualizarCategoria(id, categoria);

            return new MensagemBase<UpdateCategoriaDto>()
            {
                Message = "Categoria Atualizada com sucesso",
                StatusCode = StatusCodes.Status204NoContent
            };

        }

        public async Task <MensagemBase<Categoria>> DeletarCategoria(int id)
        {
           var categoriaASerDeletada = await BuscarCategoriasPorId(id);

            if(categoriaASerDeletada == null)
            {
                return new MensagemBase<Categoria>()
                {
                    Message = "Categoria não encontrada",
                    Object = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var categoria = await _repository.DeletarCategoria(id);
            return new MensagemBase<Categoria>()
            {
                Message = "Categoria deletada",
                StatusCode = StatusCodes.Status204NoContent
            };
        }
    }
}
