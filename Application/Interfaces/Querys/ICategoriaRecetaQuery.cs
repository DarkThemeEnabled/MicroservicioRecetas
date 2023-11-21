using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface ICategoriaRecetaQuery
    {
        Task<CategoriaReceta> GetCategoriaRecetaById(int id);
        Task<List<CategoriaReceta>> GetCategoriaRecetas();
    }
}
