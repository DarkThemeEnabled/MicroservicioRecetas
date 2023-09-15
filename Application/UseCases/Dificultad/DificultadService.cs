using Application.Interfaces;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dificultad
{
    public class DificultadService:IDificultadService
    {
        private readonly IDificultadQuery _dificultadQuery;

        public DificultadService(IDificultadQuery dificultadQuery)
        {
            _dificultadQuery = dificultadQuery;
        }

        public async Task<List<DificultadResponse>> GetListDificultad()
        {
            var dificultades = await _dificultadQuery.GetListDificultades();
            var dificultadResponse = new List<DificultadResponse>();

            foreach (var item in dificultades)
            {
                var dificultad = new DificultadResponse
                {
                    DificultadId = item.DificultadId,
                    Nombre = item.Nombre

                };
                dificultadResponse.Add(dificultad);

            }
            return dificultadResponse;

        }
    }
}
