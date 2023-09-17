using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class PasoQuery : IPasoQuery
    {
        private readonly RecetasContext _context;

        public PasoQuery(RecetasContext context)
        {
            _context = context;
        }


        public async Task<List<Paso>> GetPasosByRecetaId(Guid recetaId)
        {
            try
            {
                List<Paso> results = await _context.Pasos
                .Where(p => p.RecetaId == recetaId)
                .ToListAsync();
                return results;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
        public async Task<Paso> GetPasoById (int pasoId)
        {
            try
            {
                var paso = await _context.Pasos
                    .SingleOrDefaultAsync(p => p.PasoId == pasoId);
                return paso;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("No se encontró el paso solicitado");
            }
        }
    }
}
