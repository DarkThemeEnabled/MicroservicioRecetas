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
        Task<bool> CreateIngredienteReceta(IngredienteRecetaRequest request, Guid recetaId);
        Task<IngredienteRecetaResponse> UpdateIngredienteReceta(IngredienteRecetaRequest request, int ingRecetaId);
        Task<IngredienteRecetaDeleteResponse> DeleteIngredienteReceta(int ingRecetaId);
        Task<int> GetIngredienteRecetaBy(Guid recetaId, int ingRecetaId);
    }
}
