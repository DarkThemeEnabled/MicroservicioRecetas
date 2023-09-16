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
    }
}
