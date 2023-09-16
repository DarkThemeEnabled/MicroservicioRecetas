using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class PasosCommand:IPasosCommand
    {
        private readonly RecetasContext _context;

        public PasosCommand(RecetasContext context)
        {
            _context = context;
        }

        public async Task CreatePaso(Paso paso)
        {
            _context.Add(paso);
            await _context.SaveChangesAsync();
        }
    }
}
