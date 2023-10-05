using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;


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
            try
            {
                var recetas = await _context.Recetas.ToListAsync();
                return recetas;
            }
            
             catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<Receta> GetRecetaById(Guid id)
        {
            try
            {
                return await _context.Recetas
                    .Include(r => r.Dificultad)
                    .Include(r => r.CategoriaReceta)
                    .Include(r => r.Pasos)
                    .Include(r => r.IngredentesReceta)
                    .Include(r => r.UsuarioId)
                    .SingleOrDefaultAsync(r => r.RecetaId == id);
            }
            catch (DbUpdateException)
            {
                throw new Application.Exceptions.BadRequestt("Hubo un problema al buscar la receta");
            }
        }
    }
}
