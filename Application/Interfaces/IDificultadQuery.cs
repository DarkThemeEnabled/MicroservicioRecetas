using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDificultadQuery
    {
        public Task<List<Dificultad>> GetListDificultades();
        public Task<Dificultad> GetDificultadById(int dificultadId);
    }
}
