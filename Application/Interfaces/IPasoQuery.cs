using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPasoQuery
    {
        Task<List<Paso>> GetPasosByRecetaId(Guid recetaId);
        Task<Paso> GetPasoById(int pasoId);
        Task<int> GetDescripcionLength();
        Task<int> GetFotoLength();
        Task<int> GetPasoIdByRecetaId(Guid recetaId, int orden);
    }
}
