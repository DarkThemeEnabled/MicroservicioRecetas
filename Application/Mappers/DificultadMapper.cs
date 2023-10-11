using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class DificultadMapper
    {
        public async Task<DificultadResponse> GetDificultadResponse (Dificultad dificultad)
        {
            return new DificultadResponse
            {
                Id = dificultad.DificultadId,
                Nombre = dificultad.Nombre
            };
        }
        public async Task<List<DificultadResponse>> GetListDificultadResponse(List<Dificultad> dificutades)
        {
            List<DificultadResponse> dificultadesResponse = new();
            foreach (Dificultad dificultad in dificutades)
            {
                dificultadesResponse.Add(await GetDificultadResponse(dificultad));
            }
            return dificultadesResponse;
        }
    }

    
}
