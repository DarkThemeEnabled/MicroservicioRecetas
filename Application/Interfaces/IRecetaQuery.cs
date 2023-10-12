using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRecetaQuery
    {
        Task<List<Receta>> GetListRecetas();
        Task<Receta> GetRecetaById(Guid id);
        Task<int> GetTitleLength();
        Task<int> GetVideoLenght();
        Task<int> GetFotoRecetaLength();
    }
}
