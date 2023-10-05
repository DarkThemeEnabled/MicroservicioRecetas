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
        Task<IngredienteReceta> CreateIngredienteReceta(IngredienteReceta ingredienteReceta);
        Task<IngredienteReceta> UpdateIngredienteReceta(IngredienteReceta ingRecetaUpdate, int ingRecetaId);
        Task<IngredienteReceta> DeleteIngredienteReceta(int ingRecetaId);
    }
}
