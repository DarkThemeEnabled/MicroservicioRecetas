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

        public async Task<List<PasoResponse>> GetPasosByRecetaId (Guid recetaId)
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

        public async Task<PasoResponse> UpdatePaso(PasoRequest request, int id)
        {
            try
            { //400 404 409
                //Agregar validador de recetaID
                //Agregar validador de PasoID
                //En un futuro agregar un validador de urls con eso de las fotos. Pero más adelante!!
                //No debería de pedir que se modifique el recetaID!!!
                var unPaso = await _command.UpdatePaso(request, id);
                return await Task.FromResult(new PasoResponse
                {
                    Id = unPaso.PasoId,
                    RecetaId = unPaso.RecetaId,
                    Descripcion = unPaso.Descripcion,
                    Foto = unPaso.Foto,
                    Orden = unPaso.Orden
                });
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
                //Habría que validar si existe el id primero
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

        private Task<bool> Validacion404()
        {
            throw new NotImplementedException();
        }

        private Task<bool> Validacion409 ()
        {
            throw new NotImplementedException();
        }


    }
}

//82528494-2314-4E8E-9402-08DBB7C5D769