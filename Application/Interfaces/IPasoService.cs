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
        public Task<PasoResponse> CreatePaso(PasoRequest request);
        public Task<List<PasoResponse>> GetPasoByRecetaId(Guid recetaId);
        public Task<PasoResponse> GetPasoById(int Id);
    }
}
