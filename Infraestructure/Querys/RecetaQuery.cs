using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Querys
{
    public class RecetaQuery : IRecetaQuery
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
                var recetas = await _context.Recetas
                .Include(r => r.Dificultad)
                .Include(r => r.CategoriaReceta)
                .Include(r => r.Pasos)
                .Include(r => r.IngredentesReceta)
                .ToListAsync();

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
                    //.Include(r => r.UsuarioId)
                    .SingleOrDefaultAsync(r => r.RecetaId == id);
            }
            catch (DbUpdateException)
            {
                throw new BadRequestt("Hubo un problema al buscar la receta");
            }
        }

        public async Task<int> GetTitleLength()
        {
            try
            {
                return _context.Model.FindEntityType(typeof(Receta))
                   .FindProperty("Titulo")
                   .GetMaxLength().GetValueOrDefault();
            }
            catch (DbUpdateException)
            {
                throw new BadRequestt("Hubo un problema al encontrar el limite de la longitud del titulo");
            }

        }
        public async Task<int> GetFotoRecetaLength()
        {
            try
            {
                return _context.Model.FindEntityType(typeof(Receta))
                   .FindProperty("FotoReceta")
                   .GetMaxLength().GetValueOrDefault();
            }
            catch (DbUpdateException)
            {
                throw new BadRequestt("Hubo un problema al encontrar el limite de la longitud de la imagen");
            }
        }
        public async Task<int> GetVideoLenght()
        {
            try
            {
                return _context.Model.FindEntityType(typeof(Receta))
                   .FindProperty("Video")
                   .GetMaxLength().GetValueOrDefault();
            }
            catch (DbUpdateException)
            {
                throw new BadRequestt("Hubo un problema al encontrar el limite de la longitud del video");
            }
        }
    }
}
