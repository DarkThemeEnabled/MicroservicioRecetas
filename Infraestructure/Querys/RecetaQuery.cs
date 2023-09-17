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
                var paso = await _context.Recetas
                    .SingleOrDefaultAsync(r => r.RecetaId == id);
                return paso;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("No se encontró el paso solicitado");
            }
        }
    }
}
