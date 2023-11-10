using Application.Request;
using Application.Response;

namespace Application.Interfaces.Services
{
    public interface IRecetaService
    {

        Task<List<RecetaResponse>> GetListRecetas();
        Task<RecetaResponse> CreateReceta(RecetaRequest recetaRequest);
        Task<RecetaResponse> UpdateReceta(RecetaRequest request, Guid id);
        Task<RecetaDeleteResponse> DeleteReceta(Guid id);
        Task<RecetaResponse> GetRecetaById(Guid id);
        Task<List<RecetaGetResponse>> GetRecetaByFilter(string? titulo, int dificultad, int categoria, string? ingrediente);
        Task<List<RecetaGetResponse>> GetRecetaByString(string text);
    }
}
