using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRecetaService
    {
        
        Task<List<RecetaResponse>> GetListRecetas();
        Task<RecetaResponse> CreateReceta(RecetaRequest recetaRequest);
        Task<RecetaResponse> GetRecetaById(Guid id);

    }
}
