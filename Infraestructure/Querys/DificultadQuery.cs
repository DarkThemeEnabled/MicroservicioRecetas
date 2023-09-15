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
    public class DificultadQuery: IDificultadQuery
    {
        private readonly RecetasContext _recetasContext;

        public DificultadQuery(RecetasContext recetasContext) 
        {
            _recetasContext = recetasContext;
        }

        public async Task<List<Dificultad>> GetListDificultades()
        {
            var dificultades = await _recetasContext.Dificultades.ToListAsync();
            return dificultades;
        }
    }
}
