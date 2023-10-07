using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Azure.Core;
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

        public async Task<PasoResponse> CreatePaso(PasoRequest request, Guid recetaId)
        {
            try
            {
                Paso pasoCreado=null;
                if (await VerifyAll(request))
                {
                    var paso = new Paso
                    {
                        Descripcion = request.Descripcion,
                        Foto = request.Foto,
                        Orden = request.Orden,
                        RecetaId = recetaId,
                    };

                    pasoCreado = await _command.CreatePaso(paso);
                }
                //Agregar validador de orden (aunque en teoría es automatico, verlo despues)
                
                return await CreatePasoResponse(pasoCreado);
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del paso a crear: " + e.Message);
            }
            catch (ExceptionNotFound e)
            {
                throw new ExceptionNotFound("No se pudo agregar el paso: " + e.Message);
            }

        }

        public async Task<PasoResponse> UpdatePaso(PasoRequest request, int id)
        {
            try
            {
                if (await VerifyAll(request) && GetPasoById(id) != null) 
                {
                    var unPaso = await _command.UpdatePaso(request, id);
                    return await CreatePasoResponse(unPaso);
                }
                return new PasoResponse { };
                
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error en la implementación a la base de datos: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error en la busqueda en la base de datos: " + ex.Message);
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error en la sintaxis de la mercadería a modificar: " + ex.Message);
            }
        }
        public async Task<PasoResponse> DeletePaso(int id)
        {
            try
            {
                if(GetPasoById(id) == null) { throw new ExceptionNotFound("No existe ningún paso"); }
                Paso pasoToDelete = await _command.DeletePaso(await _query.GetPasoById(id));
                return new PasoResponse
                {
                    Id = pasoToDelete.PasoId,
                    RecetaId = pasoToDelete.RecetaId,
                    Descripcion = pasoToDelete.Descripcion,
                    Foto = pasoToDelete.Foto,
                    Orden = pasoToDelete.Orden
                };
            }
            catch (ExceptionNotFound ex) { throw new ExceptionNotFound("Error en la búsqueda del id: " + ex.Message); }
            catch (Conflict ex) { throw new Conflict("Error en la base de datos: " + ex.Message); }
            catch (ExceptionSintaxError) { throw new ExceptionSintaxError("Sintaxis incorrecta para el Id"); }
        }

        //Este capaz es innecesario ya que la receta te trae todos sus pasos
        public async Task<List<PasoResponse>> GetPasosByRecetaId(Guid recetaId)
        {
            try
            {
                var pasos = await _query.GetPasosByRecetaId(recetaId);
                var pasosResponse = new List<PasoResponse>();
                if (pasos.Count() != 0)
                {
                    foreach (var paso in pasos)
                    {
                        pasosResponse.Add(await CreatePasoResponse(paso));
                    }
                }
                return pasosResponse;
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis: " + e.Message);
            }
            catch (Conflict e)
            {
                throw new Conflict(e.Message);
            }

        }

        public async Task<PasoResponse> GetPasoById(int Id)
        {
            try
            {
                //Validar que se ingrese un int
                var paso = await _query.GetPasoById(Id);
                if (paso != null)
                {
                    return await CreatePasoResponse(paso);
                }
                else
                {
                    throw new ExceptionNotFound("No existe ningún paso con ese ID");
                }

            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis: " + e.Message);
            }
            catch (ExceptionNotFound e)
            {
                throw new ExceptionNotFound("Error en la búsqueda: " + e.Message);
            }


        }

        //------ Metodos privados ------
        
        //------ Validaciones ------
        private async Task<bool> VerifyAll(PasoRequest request)
        {
            if (request.Descripcion.Length > await _query.GetDescripcionLength()) {throw new BadRequestt("La descripción sumera el límite permitido"); }
            if (request.Foto.Length > await _query.GetFotoLength()) { throw new BadRequestt("El url de la foto supera el límite permitido"); }
            //Verificador de ints??
            return true;
        }
        //private async Task<bool> VerifyRecetaId(Guid recetaId)
        //{
        //    return (await _recService.GetRecetaById(recetaId) != null);
        //}

        //------ Creador responses ------
        private Task<PasoResponse> CreatePasoResponse(Paso unPaso)
        {
            return Task.FromResult(new PasoResponse
            {
                Id = unPaso.PasoId,
                RecetaId = unPaso.RecetaId,
                Descripcion = unPaso.Descripcion,
                Foto = unPaso.Foto,
                Orden = unPaso.Orden
            });
        }


       


    }
}

//82528494-2314-4E8E-9402-08DBB7C5D769