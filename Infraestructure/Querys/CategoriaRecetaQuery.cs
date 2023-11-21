using Application.Exceptions;
using Application.Interfaces.Querys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infraestructure.Querys
{
    public class CategoriaRecetaQuery : ICategoriaRecetaQuery
    {
        private readonly RecetasContext _context;

        public CategoriaRecetaQuery(RecetasContext context)
        {
            _context = context;
        }

        public async Task<CategoriaReceta> GetCategoriaRecetaById(int id)
        {
            return await _context.CategoriasReceta.FirstOrDefaultAsync(cr => cr.CategoriaRecetaId == id);
        }

        public async Task<List<CategoriaReceta>> GetCategoriaRecetas()
        {
            try
            {
                return await _context.CategoriasReceta.ToListAsync();
            }
            catch (DbException ex)
            {
                throw new BadRequestt("Hubo un problema en la búsqueda de listas de dificultades");
            }
        }
    }
}
