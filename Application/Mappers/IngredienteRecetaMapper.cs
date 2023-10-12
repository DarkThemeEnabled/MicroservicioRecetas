using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class IngredienteRecetaMapper
    {
        public async Task<IngredienteRecetaResponse> GetIngredienteRecetaResponse(IngredienteReceta unIngRec, string nombre)
        {
            return new IngredienteRecetaResponse
            {
                //Tiene que traer el nombre desde el microservicio 
                id = unIngRec.IngredienteRecetaId,
                nombre = nombre,
                ingredienteId = 12,
            };

        }

        public async Task<List<IngredienteRecetaResponse>> GetIngredientesRecetaResponse(ICollection<IngredienteReceta> listaIngReceta)
        {
            List<IngredienteRecetaResponse> ingRecetasResponse = new();
            foreach (IngredienteReceta ingReceta in listaIngReceta)
            {
                ingRecetasResponse.Add(await GetIngredienteRecetaResponse(ingReceta,"prueba"));
            }
            return ingRecetasResponse;
        }

        public async Task<IngredienteRecetaDeleteResponse> GetIngredienteDeleteResponse(IngredienteReceta unIngRec)
        {
            return (new IngredienteRecetaDeleteResponse
            {
                id = unIngRec.IngredienteRecetaId,
                //Tiene que traer el nombre desde el microservicio ingrediente
                nombre = "sarasa",
            });
        }
    }
}
