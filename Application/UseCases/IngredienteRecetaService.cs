using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class IngredienteRecetaService : IIngredienteRecetaService
    {
        private readonly IIngredienteRecetaQuery _query;
        private readonly IIngredienteRecetaCommand _command;
        public IngredienteRecetaService(IIngredienteRecetaQuery query, IIngredienteRecetaCommand command)
        {
            _query = query;
            _command = command;
        }
        public async Task<bool> CreateIngredienteReceta(IngredienteRecetaRequest request, Guid recetaId)
        {
            try
            {
                //El validador de ingrecetaId tiene que venir por conexión con el microservicio ingredientes
                //Validador de si existe la receta id
                if (await VerifyAll(request, recetaId, 0))
                {
                    IngredienteReceta unIngReceta = new IngredienteReceta
                    {
                        RecetaId = recetaId,
                        IngredienteId = request.ingredienteId,
                        cantidad = request.cantidad
                    };
                    return await _command.CreateIngredienteReceta(unIngReceta);
                }
                throw new Exception ("Ocurrió un error inesperado");

            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Ocurrió un error en la sintaxis: ");
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Ocurrió un error en la búsqueda del ingrediente: ");
            }
            catch (Conflict ex)
            {
                //si ya existe ese ingrediente en la receta, lo rajamos
                throw new Conflict("Ocurrió un error en la carga de ingredientes: "+ex.Message);
            }

            
        }

        public async Task<IngredienteRecetaDeleteResponse> DeleteIngredienteReceta(int ingRecetaId)
        {
            try
            {
                IngredienteReceta ingReceta = await _query.GetIngRecetaById(ingRecetaId);
                if (ingReceta == null) { throw new ExceptionNotFound("No existe ese ingrediente en la receta solicitada"); }
                else
                {
                    return await GenerateIngredienteDeleteResponse(await _command.DeleteIngredienteReceta(ingReceta));
                }
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Ocurrió un error en la búsqueda: " + ex.Message);
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Hubo un error en la sintaxis: " + ex.Message);
            }
        }
        

        public async Task<IngredienteRecetaResponse> UpdateIngredienteReceta(IngredienteRecetaRequest request, int ingRecetaId)
        {
            try
            {
                //El validador de ingrecetaId tiene que venir por conexión con el microservicio ingredientes
                //Validador de si existe la receta id
                if (await VerifyAll(request, null, ingRecetaId))
                { 
                    IngredienteReceta unIngReceta = await _command.UpdateIngredienteReceta(request,ingRecetaId, await _query.GetRecetaIdByIngRecetaId(ingRecetaId));
                    return await GenerateIngredienteRecetaResponse(unIngReceta);
                }
                throw new Exception("Ocurrió un error inesperado");

            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Ocurrió un error en la sintaxis: ");
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Ocurrió un error en la búsqueda del ingrediente: ");
            }
            catch (Conflict ex)
            {
                //si ya existe ese ingrediente en la receta, lo rajamos
                throw new Conflict("Ocurrió un error en la carga de ingredientes: " + ex.Message);
            }
        }

        public async Task<int> GetIngredienteRecetaBy (Guid recetaId, int ingredienteId)
        {
            return await _query.GetIngRecetaByRecetaId(recetaId, ingredienteId);
        }




        //----- Metodos privados -----

        //----- Generadores de responses ------
        private Task<IngredienteRecetaResponse> GenerateIngredienteRecetaResponse (IngredienteReceta unIngRec)
        {
            return Task.FromResult(new IngredienteRecetaResponse
            {
                //Tiene que traer el nombre desde el microservicio 
                id = unIngRec.IngredienteRecetaId,
                nombre = "sarasa",
                ingredienteId = 12,
            });

        }
        private async Task<IngredienteRecetaDeleteResponse> GenerateIngredienteDeleteResponse (IngredienteReceta unIngRec)
        {
            return (new IngredienteRecetaDeleteResponse
            {
                id = unIngRec.IngredienteRecetaId,
                //Tiene que traer el nombre desde el microservicio ingrediente
                nombre = "sarasa",
            });
        }

        //------ Validadores -----
        private async Task<bool> VerifyAll(IngredienteRecetaRequest request, Guid? recetaId, int ingRecetaId)
        {
            //ver los validadores de ints
            //Ver este porque tiene que lo que conecta al microservicio :D
            if (request.ingredienteId == 0) { throw new ExceptionNotFound("No existe el ingrediente"); }
            if (request.cantidad < 1) { throw new ExceptionSintaxError("La cantidad no puede ser menor a 1"); }
            // ^--- Con la llamada al microservicio ingrediente, pedir el nombre para mostrar el ingrediente que es menor a 0 :D
            if (recetaId != null && await _query.ExistIngredienteInIngReceta((Guid)recetaId,request.ingredienteId)) { throw new Conflict("Ya existe el ingrediente en la receta");}
            // ^--- Con la llamada al microservicio ingrediente, pedir el nombre para mostrar el ingrediente que se está repitiendo :D
            if (ingRecetaId > 0 && _query.GetIngRecetaById(ingRecetaId) == null) { throw new ExceptionNotFound("No existe el ingrediente"); }
            return true;
        }
    }
}
