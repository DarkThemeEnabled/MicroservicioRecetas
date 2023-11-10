using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Mappers
{
    public interface IDificultadMapper
    {
        Task<DificultadResponse> GetDificultadResponse(Dificultad dificultad);
        Task<List<DificultadResponse>> GetListDificultadResponse(List<Dificultad> dificutades);
    }
}
