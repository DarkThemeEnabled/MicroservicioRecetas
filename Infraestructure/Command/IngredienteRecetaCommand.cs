using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class IngredienteRecetaCommand : IIngredienteRecetaCommand
    {
        private readonly RecetasContext _context;

        public IngredienteRecetaCommand(RecetasContext context)
        {
            _context = context;
        }
        public Task<IngredienteReceta> CreateIngredienteReceta(IngredienteReceta ingredienteReceta)
        {
            throw new NotImplementedException();
        }

        public Task<IngredienteReceta> DeleteIngredienteReceta(int ingRecetaId)
        {
            throw new NotImplementedException();
        }

        public Task<IngredienteReceta> UpdateIngredienteReceta(IngredienteReceta ingRecetaUpdate, int ingRecetaId)
        {
            throw new NotImplementedException();
        }
    }
}
