using Application.Exceptions;
using Application.Interfaces;
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
    public class PasoCommand:IPasoCommand
    {
        private readonly RecetasContext _context;

        public PasoCommand(RecetasContext context)
        {
            _context = context;
        }

        public async Task<Paso> CreatePaso(Paso paso)
        {
            try 
            {
                _context.Add(paso);
                await _context.SaveChangesAsync();
                return paso;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("No se encontró el paso solicitado");
            }

        }
    }
}
