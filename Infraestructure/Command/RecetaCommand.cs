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
    public class RecetaCommand: IRecetaCommand
    {
        private readonly RecetasContext _context;

        public RecetaCommand(RecetasContext context)
        {
            _context = context;
        }

        public async Task CreateReceta(Receta receta )
        {
            _context.Add(receta );
            await _context.SaveChangesAsync();
        }
    }
}
