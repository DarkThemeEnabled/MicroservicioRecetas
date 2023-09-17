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

namespace Application.UseCases.SReceta
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaQuery _query;
        private readonly IRecetaCommand _command;

        public RecetaService(IRecetaQuery recetaQuery, IRecetaCommand recetaCommand)
        {
            _query = recetaQuery;
            _command = recetaCommand;
        }

        
        public async Task<RecetaResponse> CreateReceta(RecetaRequest recetaRequest)
        {
            try
            {
                //Crear validador tiempopreparacion(string) a timespan
                //Crear validador dificultadID
                //Crear validador UsuarioID (Este debería validarse por el microservicio de usuario, hay que ver como es lo del token)
                //Crear validador CategoríaRecetaId

                //Los válidadores yo, Lucas Gomez, los creo como un método private para poder reutilizarlos en cualquier parte del código
                //podemos charlarlo si quieren seguir mi forma de realizarlo o no 
                TimeSpan.TryParse(recetaRequest.TiempoPreparacion, out TimeSpan tiempoPreparacion);
                var receta = new Receta
                {
                    CategoriaRecetaId = recetaRequest.CategoriaRecetaId,
                    DificultadId = recetaRequest.DificultadId,
                    UsuarioId = recetaRequest.UsuarioId,
                    Titulo = recetaRequest.Titulo,
                    FotoReceta = recetaRequest.FotoReceta,
                    Video = recetaRequest.Video,
                    TiempoPreparacion = tiempoPreparacion
                };

                Receta recetaCreada= await _command.CreateReceta(receta);
                return await CreateRecetaResponse(recetaCreada);
                //return new ResponseMessage(201, result);  Devolver el statusCode es innecesario ya que lo estamos indicando en el return del controller :)
                //public async Task<ResponseMessage> CreateReceta(RecetaRequest recetaRequest) <--- Devuelve un ResponseMessage que no se utiliza en el controller
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis de la receta a crear: " + e.Message);
            }
            catch (Conflict e)
            {
                throw new ExceptionNotFound("No se pudo agregar la receta: " + e.Message);
            }


        }
        //Hay que crear un GetRecetaResponse que te devuelva los datos de la receta pero que traiga los pasos que vinculados a esa receta
        public async Task<RecetaResponse> GetRecetaById(Guid id)
        {
            try
            {
                //implementar este validador en un metodo aparte
                if (!Guid.TryParse(id.ToString(), out id)) { throw new ExceptionSintaxError(); }
                var paso = await _query.GetRecetaById(id);
                if (paso != null)
                {
                    return await CreateRecetaResponse(paso);
                }
                else
                {
                    throw new ExceptionNotFound("No existe ninguna receta con ese ID");
                }
                
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del id a buscar, pruebe ingresar el id con el formato válido");
            }
            catch (ExceptionNotFound e)
            {
                throw new ExceptionNotFound("Error en la búsqueda: " + e.Message);
            }
        }

        public async Task<List<RecetaResponse>> GetListRecetas()
        {
            //Después vamos a tener que crear más métodos de búsqueda aparte de este (Buscar una receta por usuario, todas las recetas de un usuario, por nombre, por dificultad, por categoria, por id, pensar mas)
            //En este caso, no veo la necesidad de realizar un try/catch ya que devuelve una lista con recetas o vacía
            var recetas = await _query.GetListRecetas();
            var recetasResponse = new List<RecetaResponse>();

            foreach (var receta in recetas)
            {
                recetasResponse.Add(await CreateRecetaResponse(receta));
            }
            return recetasResponse;
        }

        //Métodos privados para RecetaService
        private Task<RecetaResponse> CreateRecetaResponse (Receta unaReceta)
        {
            var receta = new RecetaResponse
            {
                RecetaId = unaReceta.RecetaId,
                CategoriaRecetaId = unaReceta.CategoriaRecetaId,
                DificultadId = unaReceta.DificultadId,
                FotoReceta = unaReceta.FotoReceta,
                TiempoPreparacion = unaReceta.TiempoPreparacion.ToString(),
                Titulo = unaReceta.Titulo,
                Video = unaReceta.Video
            };
            return Task.FromResult(receta);
        }
    }
}
