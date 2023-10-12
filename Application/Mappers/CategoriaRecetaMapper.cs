using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class CategoriaRecetaMapper
    {
        public async Task<CategoriaRecetaResponse> GetCategoriaRecetaResponse(CategoriaReceta categoriaReceta)
        {
            return new CategoriaRecetaResponse
            {
                Id = categoriaReceta.CategoriaRecetaId,
                Nombre = categoriaReceta.Nombre
            };
        }
    }
}
