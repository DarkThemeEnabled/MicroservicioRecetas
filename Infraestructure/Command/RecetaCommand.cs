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
    public class RecetaCommand: IRecetaCommand
    {
        private readonly RecetasContext _context;

        public RecetaCommand(RecetasContext context)
        {
            _context = context;
        }

        public async Task<Receta> CreateReceta(Receta receta )
        {
            try
            {
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return receta;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<Receta> DeleteReceta(Receta unaReceta)
        {
            try
            {
                _context.Remove(unaReceta);
                await _context.SaveChangesAsync();
                return unaReceta;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("No se pudo eliminar la receta");
            }
        }

        public async Task<Receta> UpdateReceta(RecetaRequest recetaRequest, Guid recetaId)
        {
            try
            {
                //Falta que modifique: Pasos, Ingredientes, Usuario(Discutir ocn el grupo)
                var recetaToUpdate = await _context.Recetas.FirstOrDefaultAsync(r => r.RecetaId.Equals(recetaId));
                recetaToUpdate.Titulo = recetaRequest.Titulo;
                recetaToUpdate.DificultadId = recetaRequest.DificultadId;
                recetaToUpdate.FotoReceta = recetaRequest.FotoReceta;
                recetaToUpdate.Video = recetaRequest.Video;
                await _context.SaveChangesAsync();

                return recetaToUpdate;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
