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

        public async Task<MensagemBase<IEnumerable<ReadCategoriaDto>>> BuscarCategorias()
        {
            var buascarTodasCategorias = await _repository.Buscarcategorias();
            if (buascarTodasCategorias.Count() > 0 || buascarTodasCategorias.Any())
            {
                var response = MapperCategoria.ParaListaReadCategoriaDto(buascarTodasCategorias);
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

        public async Task<MensagemBase<ReadCategoriaDto>> BuscarCategoria(int id)
        {
            try
            {
                var buascarTodasCategorias = await _repository.BuscarCategoria(id);
                if (buascarTodasCategorias != null)
                {
                    var response = MapperCategoria.ParaListaReadCategoriaDto(buascarTodasCategorias).FirstOrDefault();
                    return new MensagemBase<ReadCategoriaDto>()
                    {
                        Object = response,
                        StatusCode = StatusCodes.Status200OK,
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
        public async Task<MensagemBase<CreateCategoriaDto>> CriarCategoria(CreateCategoriaDto categoriaDto)
        {
            try
            {
                var buscaCategorias = await _repository.VerificarSeExisteCategoria(categoriaDto.Nome);


                if (buscaCategorias == true)
                    return new MensagemBase<CreateCategoriaDto>()
                    {
                        Message = "A categoria ja existe",
                        Object = null,
                        StatusCode = StatusCodes.Status204NoContent
                    };

                Categoria categoria = MapperCategoria.ParaCategoria(categoriaDto);
                var response = await _repository.CriarCategoria(categoria);

                return new MensagemBase<CreateCategoriaDto>()
                {
                    Message = "Categoria criada com sucesso",
                    Object = categoriaDto,
                    StatusCode = StatusCodes.Status201Created
                };


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MensagemBase<UpdateCategoriaDto>> AtualizarCategoria(int id, UpdateCategoriaDto updateCategoria)
        {
            bool existeCategoria = await _repository.VerificarSeExisteCategoria(updateCategoria.Nome);
            if (existeCategoria == true)
            {
                return new MensagemBase<UpdateCategoriaDto>()
                {
                    Message = "Ops! já existe uma categoria com esse nome",
                    Object = null,
                    StatusCode = StatusCodes.Status422UnprocessableEntity
                };
            }

            Categoria categoria = MapperCategoria.DeUpdateCategoriaDtoParaCategoria(updateCategoria);
            int Atualizar = await _repository.AtualizarCategoria(id, categoria);

            return new MensagemBase<UpdateCategoriaDto>()
            {
                Message = "Categoria Atualizada com sucesso",
                StatusCode = StatusCodes.Status204NoContent
            };

        }

        public async Task<MensagemBase<Categoria>> DeletarCategoria(int id)
        {
            var categoriaASerDeletada = await BuscarCategoria(id);

            if (categoriaASerDeletada == null)
            {
                return new MensagemBase<Categoria>()
                {
                    Message = "Categoria não encontrada",
                    Object = null,
                    StatusCode = StatusCodes.Status422UnprocessableEntity
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
