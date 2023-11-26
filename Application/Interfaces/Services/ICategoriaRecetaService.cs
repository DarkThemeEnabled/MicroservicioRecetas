using Application.Response;

namespace Application.Interfaces.Services
{
    public interface ICategoriaRecetaService
    {
        Task<bool> ValidateCategoriaRecetaById(int categoriaRecetaId);

        Task<CategoriaRecetaResponse> GetCategoriaRecetaById(int id);
        Task<List<CategoriaRecetaResponse>> GetCategoriasReceta();
    }
}
