using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPasoService
    {
        Task<PasoResponse> CreatePaso(PasoRequest request, Guid recetaId);
        Task<PasoResponse> UpdatePaso(PasoRequest request, int id);
        Task<PasoResponse> DeletePaso(int id);
        Task<List<PasoResponse>> GetPasosByRecetaId(Guid recetaId);
        Task<PasoResponse> GetPasoById(int Id);
        Task<int> GetPasoidByRecetaId(Guid recetaId, int paso);

    }
}
