using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class IngredienteRecetaQuery : IIngredienteRecetaQuery
    {
        private readonly RecetasContext _context;

        public IngredienteRecetaQuery(RecetasContext context)
        {
            _context = context;
        }

        public Task<IngredienteReceta> GetIngredienteRecetaById(int ingRecetaId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteReceta>> GetIngredienteRecetaByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteReceta>> GetIngredienteRecetaByTipo(string tipo)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteReceta>> GetIngredienteRecetaByTipoMedida(string medida)
        {
            throw new NotImplementedException();
        }

        public Task<List<IngredienteReceta>> GetIngredientesRecetaById(int ingRecetaId)
        {
            throw new NotImplementedException();
        }
    }
}
