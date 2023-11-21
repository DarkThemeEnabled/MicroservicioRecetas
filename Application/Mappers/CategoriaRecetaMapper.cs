using Application.Interfaces.Mappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class CategoriaRecetaMapper : ICategoriaRecetaMapper
    {
        public async Task<CategoriaRecetaResponse> GetCategoriaRecetaResponse(CategoriaReceta categoriaReceta)
        {
            return new CategoriaRecetaResponse
            {
                id = categoriaReceta.CategoriaRecetaId,
                nombre = categoriaReceta.Nombre
            };
        }

        public async Task<List<CategoriaRecetaResponse>> GetListCategoriaRecetaResponse(List<CategoriaReceta> Categorias)
        {
            List<CategoriaRecetaResponse> categoriasResponse = new();
            foreach (CategoriaReceta unaCategoria in Categorias)
            {
                categoriasResponse.Add(await GetCategoriaRecetaResponse(unaCategoria));
            }
            return categoriasResponse;
        }
    }
}
