using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIngredienteRecetaQuery
    {
        Task<List<IngredienteReceta>> GetIngredientesRecetaById(int ingRecetaId);
        Task<IngredienteReceta> GetIngredienteRecetaById(int ingRecetaId);
        Task<List<IngredienteReceta>> GetIngredienteRecetaByName(string name);
        Task<List<IngredienteReceta>> GetIngredienteRecetaByTipo(string tipo);
        Task<List<IngredienteReceta>> GetIngredienteRecetaByTipoMedida(string medida);
    }
}
