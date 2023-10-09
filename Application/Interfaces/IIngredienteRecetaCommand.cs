using Application.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIngredienteRecetaCommand
    {
        Task<bool> CreateIngredienteReceta(IngredienteReceta ingredienteReceta);
        Task<IngredienteReceta> UpdateIngredienteReceta(IngredienteRecetaRequest ingRecetaUpdate, int ingRecetaId, Guid recetaId );
        Task<IngredienteReceta> DeleteIngredienteReceta(IngredienteReceta ingReceta);
    }
}
