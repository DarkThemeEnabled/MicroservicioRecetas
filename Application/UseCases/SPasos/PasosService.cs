using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.SPasos
{
    public class PasosService:IPasosService
    {
        private readonly IPasosCommand _command;

        public PasosService(IPasosCommand command)
        {
            _command = command;
        }

        public async Task<ResponseMessage> CreatePaso(PasoRequest request)
        {
            var paso = new Paso
            {
                Descripcion = request.Descripcion,
                Foto = request.Foto,
                Orden = request.Orden,
                RecetaId = request.RecetaId,
            };

            await _command.CreatePaso(paso);
            var result = new PasoResponse
            {
                RecetaId = request.RecetaId,
                Descripcion = request.Descripcion,
                Foto = request.Foto,
                Orden = request.Orden

            };
            return new ResponseMessage(201, result);
        }
    }
}
