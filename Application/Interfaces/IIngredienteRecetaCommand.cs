using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IIngredienteRecetaCommand
    {
        Task<IngredienteReceta> CreateIngredienteReceta(IngredienteReceta ingredienteReceta);
        Task<IngredienteReceta> UpdateIngredienteReceta(IngredienteRecetaRequest ingRecetaUpdate, int ingRecetaId, Guid recetaId);
        Task<IngredienteReceta> DeleteIngredienteReceta(IngredienteReceta ingReceta);
        Task<bool> DeleteAllIngRecetaByRecetaId(Guid recetaId);
    }
}
