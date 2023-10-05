using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class IngredienteRecetaService : IIngredienteRecetaService
    {
        private readonly IIngredienteRecetaQuery _query;
        private readonly IIngredienteRecetaCommand _command;
        public IngredienteRecetaService(IIngredienteRecetaQuery query, IIngredienteRecetaCommand command)
        {
            _query = query;
            _command = command;
        }
        public async Task<IngredienteRecetaResponse> CreateIngredienteReceta(IngredienteRecetaRequest request, Guid recetaId)
        {
            try
            {
                //El validador de ingrecetaId tiene que venir por conexión con el microservicio ingredientes
                //Validador de si existe la receta id
                IngredienteReceta unIngReceta = new IngredienteReceta
                {
                    RecetaId = recetaId,
                    IngredienteId = request.ingredienteId,
                    cantidad = request.cantidad
                };
                unIngReceta = await _command.CreateIngredienteReceta(unIngReceta);
                return await GenerateIngredienteRecetaResponse(unIngReceta);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }

        public Task<IngredienteRecetaResponse> UpdateIngredienteReceta(IngredienteRecetaRequest request, int ingRecetaId)
        {
            throw new NotImplementedException();
        }

        public Task<IngredienteRecetaResponse> DeleteIngredienteReceta(int ingRecetaId)
        {
            throw new NotImplementedException();
        }

        public Task<IngredienteRecetaResponse> GetIngredienteRecetaById(int ingRecetaId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteRecetaResponse>> GetIngredienteRecetaByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteRecetaResponse>> GetIngredienteRecetaByTipo(string tipo)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteRecetaResponse>> GetIngredienteRecetaByTipoMedida(string medida)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteRecetaResponse>> GetIngredientesRecetaById(int ingRecetaId)
        {
            throw new NotImplementedException();
        }




        // Metodos privados

        private Task<IngredienteRecetaResponse> GenerateIngredienteRecetaResponse (IngredienteReceta unIngRec)
        {
            return Task.FromResult(new IngredienteRecetaResponse
            {
                id = unIngRec.IngredienteRecetaId,
                receta = new RecetaResponse
                {
                    RecetaId = unIngRec.RecetaId,
                    //falta todo lo demás
                },
                nombre = "sarasa",
                ingredienteId = 12,
            });

        }
    }
}
