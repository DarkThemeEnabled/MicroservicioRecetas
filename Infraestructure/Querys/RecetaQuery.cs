using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class RecetaQuery: IRecetaQuery
    {
        private readonly RecetasContext _context;

        public RecetaQuery(RecetasContext context)
        {
            _context = context;
        }

        public async Task<List<Receta>> GetListRecetas()
        {
            var recetas = await _context.Recetas.ToListAsync();
            return recetas;
        }
    }
}
