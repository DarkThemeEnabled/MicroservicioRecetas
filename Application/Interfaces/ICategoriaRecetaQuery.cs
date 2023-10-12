using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICategoriaRecetaQuery
    {
        Task<CategoriaReceta> getCategoriaRecetaById(int id);
    }
}
