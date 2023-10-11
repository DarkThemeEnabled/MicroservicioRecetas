using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class IngredienteRecetaMapper
    {
        public async Task<IngredienteRecetaResponse> GetIngredienteRecetaResponse(IngredienteReceta unIngRec)
        {
            return new IngredienteRecetaResponse
            {
                //Tiene que traer el nombre desde el microservicio 
                id = unIngRec.IngredienteRecetaId,
                nombre = "sarasa",
                ingredienteId = 12,
            };

        }

        public async Task<List<IngredienteRecetaResponse>> GetIngredientesRecetaResponse(ICollection<IngredienteReceta> listaIngReceta)
        {
            List<IngredienteRecetaResponse> ingRecetasResponse = new();
            foreach (IngredienteReceta ingReceta in listaIngReceta)
            {
                ingRecetasResponse.Add(await GetIngredienteRecetaResponse(ingReceta));
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
