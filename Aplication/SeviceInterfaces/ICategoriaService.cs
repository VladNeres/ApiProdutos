using ConnectionSql.Dtos;
using Domain.Messages;
using Domain.ViewlModels;


namespace Aplication.interfaces
{
    public interface ICategoriaService
    {
        Task<MensagemBase<IEnumerable<ReadCategoriaDto>>> BuscarTodasCategorias();
        Task<MensagemBase<ReadCategoriaDto>> BuscarCategoriasPorId(int id);
        Task<MensagemBase<CreateCategoriaDto>> CriarCategoria(CreateCategoriaDto categoriaDto);
        Task<MensagemBase<UpdateCategoriaDto>> AtualizarCategoria(int id, UpdateCategoriaDto updateCategoria);
        Task<MensagemBase<Categoria>> DeletarCategoria(int id);
    }
}
