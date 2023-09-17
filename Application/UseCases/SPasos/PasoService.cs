using Application.Exceptions;
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
    public class PasoService : IPasoService
    {
        private readonly IPasoCommand _command;
        private readonly IPasoQuery _query;

        public PasoService(IPasoCommand command, IPasoQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<PasoResponse> CreatePaso(PasoRequest request)
        {
            try
            {
                //Agregar validador de recetaID
                //Agregar validador de orden (aunque en teoría es automatico, verlo despues)
                var paso = new Paso
                {
                    Descripcion = request.Descripcion,
                    Foto = request.Foto,
                    Orden = request.Orden,
                    RecetaId = request.RecetaId,
                };

                Paso pasoCreado = await _command.CreatePaso(paso);
                return await CreatePasoResponse(pasoCreado);
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del paso a crear: " + e.Message);
            }
            catch (Conflict e)
            {
                throw new Conflict("No se pudo agregar el paso: " + e.Message);
            }

        }

        public async Task<List<PasoResponse>> GetPasoByRecetaId (Guid recetaId)
        {
            //Agregar validador de recetaID
            try
            {
                var pasos = await _query.GetPasosByRecetaId(recetaId);
                var pasosResponse = new List<PasoResponse>();
                foreach (var paso in pasos)
                {
                    pasosResponse.Add(await CreatePasoResponse(paso));
                }
                return pasosResponse;
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del paso a crear: " + e.Message);
            }
            catch (Conflict e)
            {
                throw new Conflict("No se pudo agregar el paso: " + e.Message);
            }
            //Me faltan los catch!

        }
        public async Task<PasoResponse> GetPasoById(int Id)
        {
            //Agregar validador de PasoID
            try
            {
                var paso = await _query.GetPasoById(Id);
                return await CreatePasoResponse(paso);
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del paso a crear: " + e.Message);
            }
            catch (Conflict e)
            {
                throw new Conflict("No se pudo agregar el paso: " + e.Message);
            }


        }

        private Task<PasoResponse> CreatePasoResponse(Paso unPaso)
        {
            var paso = new PasoResponse
            {
                Id = unPaso.PasoId,
                RecetaId = unPaso.RecetaId,
                Descripcion = unPaso.Descripcion,
                Foto = unPaso.Foto,
                Orden = unPaso.Orden
            };
            return Task.FromResult(paso);
        }
    }
}
