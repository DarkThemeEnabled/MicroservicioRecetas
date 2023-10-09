using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> CreateIngredienteReceta(IngredienteReceta ingReceta)
        {
            try
            {
                _context.Add(ingReceta);
                return await _context.SaveChangesAsync() == 2;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("No se pudo eliminar la receta");
            }
        }

        public async Task<IngredienteReceta> DeleteIngredienteReceta(IngredienteReceta ingReceta)
        {
            try
            {
                _context.Remove(ingReceta);
                await _context.SaveChangesAsync();
                return ingReceta;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("No se pudo eliminar la receta");
            }
        }

        public async Task<IngredienteReceta> UpdateIngredienteReceta(IngredienteRecetaRequest ingRecetaUpdate, int ingRecetaId, Guid recetaId)
        {
            var ingRecetaToUpdate = await _context.IngredientesRecetas.FirstOrDefaultAsync(ir => ir.IngredienteRecetaId == ingRecetaId);

            ingRecetaToUpdate.cantidad = ingRecetaUpdate.cantidad;
            ingRecetaToUpdate.IngredienteId = ingRecetaUpdate.ingredienteId;
            ingRecetaToUpdate.RecetaId = recetaId;
            await _context.SaveChangesAsync();
            return ingRecetaToUpdate;
        }
    }
}
