using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIngredienteRecetaService
    {
        Task<IngredienteRecetaResponse> CreateIngredienteReceta(IngredienteRecetaRequest request, Guid recetaId);
        Task<IngredienteRecetaResponse> UpdateIngredienteReceta(IngredienteRecetaRequest request, int ingRecetaId);
        Task<IngredienteRecetaResponse> DeleteIngredienteReceta(int ingRecetaId);
        Task<List<IngredienteRecetaResponse>> GetIngredientesRecetaById(int ingRecetaId);
        Task<IngredienteRecetaResponse> GetIngredienteRecetaById(int ingRecetaId);
        Task<List<IngredienteRecetaResponse>> GetIngredienteRecetaByName(string name);
        Task<List<IngredienteRecetaResponse>> GetIngredienteRecetaByTipo(string tipo);
        Task<List<IngredienteRecetaResponse>> GetIngredienteRecetaByTipoMedida(string medida);
    }
}
