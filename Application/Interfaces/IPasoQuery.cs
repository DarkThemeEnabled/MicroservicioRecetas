using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
