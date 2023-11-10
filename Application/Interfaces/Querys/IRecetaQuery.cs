using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface IRecetaQuery
    {
        Task<List<Receta>> GetListRecetas();
        Task<Receta> GetRecetaById(Guid id);
        Task<List<Receta>> GetRecetasByFilters(string? titulo, int dificultad, int categoria, string? ingrediente);
        Task<List<Receta>> GetRecetasByString(string text);
        Task<int> GetTitleLength();
        Task<int> GetVideoLenght();
        Task<int> GetFotoRecetaLength();
    }
}
