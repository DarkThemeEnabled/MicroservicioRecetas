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

namespace Application.UseCases.SReceta
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaQuery _query;
        private readonly IRecetaCommand _command;
        private readonly IPasoService _pasoService;
        private readonly ICategoriaRecetaService _categoriaService;
        private readonly IDificultadService _dificultadService;
        //private readonly IIngredienteRecetaService _ingRecetaService;

        public RecetaService(IRecetaQuery recetaQuery, IRecetaCommand recetaCommand, IPasoService pasoService, ICategoriaRecetaService categoriaService, IDificultadService dificultadService)//, IIngredienteRecetaService ingredienteRecetaService)
        {
            _query = recetaQuery;
            _command = recetaCommand;
            _pasoService = pasoService;
            _categoriaService = categoriaService;
            _dificultadService = dificultadService;
            //_ingRecetaService = ingredienteRecetaService;
        }

        //------ Metodos ABM ------
        public async Task<RecetaResponse> CreateReceta(RecetaRequest recetaRequest)
        {
            try
            {
                Receta recetaCreada = null;
                if(await VerifyAll(recetaRequest))
                {
                    TimeSpan tiempoPreparacion = await GetHorario(recetaRequest.TiempoPreparacion);
                    Receta receta = new Receta
                    {
                        CategoriaRecetaId = recetaRequest.CategoriaRecetaId,
                        DificultadId = recetaRequest.DificultadId,
                        UsuarioId = recetaRequest.UsuarioId,
                        Titulo = recetaRequest.Titulo,
                        FotoReceta = recetaRequest.FotoReceta,
                        Video = recetaRequest.Video,
                        TiempoPreparacion = tiempoPreparacion,
                        IngredentesReceta = new List<IngredienteReceta>(),
                        Pasos = new List<Paso>(),
                };
                    recetaCreada = await _command.CreateReceta(receta);
                }
                recetaRequest.ListaPasos.ForEach(paso => _pasoService.CreatePaso(paso, recetaCreada.RecetaId));
                //recetaRequest.ListaIngredienteReceta.ForEach(ingReceta => _ingRecetaService.CreateIngredienteReceta(ingReceta, recetaCreada.RecetaId));
                return await CreateRecetaResponse(recetaCreada);
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis de la receta a crear: " + e.Message);
            }
            catch (ExceptionNotFound e)
            {
                throw new ExceptionNotFound("No se pudo agregar la receta: " + e.Message);
            }
            catch (BadRequestt e)
            {
                throw new BadRequestt(e.Message);
            }


        }

        public async Task<RecetaResponse> UpdateReceta(RecetaRequest recetaRequest, Guid id)
        {
            try
            {
                //Agregar validador de recetaID
                //Ver como hacer para que se muestren los pasos de dicha receta
                //En un futuro agregar un validador de urls con eso de las fotos. Pero más adelante!!
                Receta unaReceta = null;
                if (! await VerifyRecetaId(id)) { throw new ExceptionNotFound("El id de la receta no existe"); }
                if (await VerifyAll(recetaRequest))
                {
                    //Acá hay que verificar los conflictos posibles (qué conflictos podría haber...)
                    //Posibles conflictos: mismo titulo de receta con el mismo usuario - 
                    TimeSpan tiempoPreparacion = await GetHorario(recetaRequest.TiempoPreparacion);
                    unaReceta = await _command.UpdateReceta(recetaRequest, id);
                }
                return await CreateRecetaResponse(unaReceta);
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

        public async Task<RecetaDeleteResponse> DeleteReceta(Guid id)
        {
            try
            {
                //Hay que ver a nivel de usuario como se crea todo esto porque va de la mano con lo de usuario :O
                //Cuando se borre la receta tenemos que implementar que se borren todos los pasos <----- (De acá vendría el conflict)
                if (!await VerifyRecetaId(id)) { throw new ExceptionNotFound("El id no existe"); }
                Receta recetaToDelete = await _command.DeleteReceta(await _query.GetRecetaById(id));
                return new RecetaDeleteResponse
                {
                    id = recetaToDelete.RecetaId,
                    titulo = recetaToDelete.Titulo,
                };
            }
            catch (ExceptionNotFound ex) { throw new ExceptionNotFound("Error en la búsqueda de la receta: " + ex.Message); }
            catch (Conflict ex) { throw new Conflict("Error en la base de datos: " + ex.Message); }
            catch (ExceptionSintaxError) { throw new ExceptionSintaxError("Sintaxis incorrecta para el Id"); }
        }


        //------ Metodos De busqueda -----
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

        //----- Métodos privados -----

        //----- Generadores de responses ------
        private Task<RecetaResponse> CreateRecetaResponse(Receta unaReceta)
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

        // ------ Validadores ------

        // Validador de todos los atributos de Receta

        private async Task<bool> VerifyAll(RecetaRequest recetaRequest)
        {
            //Validador de enteros?
            //Crear validador UsuarioID (Este debería validarse por el microservicio de usuario, hay que ver como es lo del token)
            //Validador de vídeos o foto receta???? Esto tenemos que ver como implementarlo. Se supone que se sube una imagen
            //Validador de titulo

            if (!await VerifyDificultadId(recetaRequest.DificultadId)) { throw new ExceptionNotFound("No existe ninguna categoría para ese ID"); }
            if (!VerifyInt(recetaRequest.DificultadId)) { throw new ExceptionSintaxError("Formato érroneo para el id de dificultad, pruebe un entero"); }

            if (!await VerifyCategoriaRecetaId(recetaRequest.CategoriaRecetaId)) { throw new ExceptionNotFound("No existe ninguna categoría para ese ID"); }
            if (!VerifyInt(recetaRequest.CategoriaRecetaId)) { throw new ExceptionSintaxError("Formato érroneo para el id de categoriaReceta, pruebe un entero"); }

            //Acá tiene que ser la llamada al otro microservicio para obtener los datos del ingredienteReceta
            if (!recetaRequest.ListaIngredienteReceta.All(item => VerifyInt(item))) { throw new ExceptionSintaxError("Formato érroneo para el id de categoriaReceta, pruebe un entero"); }

            if (!await VerifyTitleLength(recetaRequest.Titulo)) { throw new ExceptionSintaxError("El titulo es demasiado extenso"); }
            if (!await VerifyFotoRecetaLenght(recetaRequest.FotoReceta)) { throw new ExceptionSintaxError("El url de la imagen es demasiado extenso"); }
            if (!await VerifyVideoLenght(recetaRequest.Video)) { throw new ExceptionSintaxError("El url del video es demasiado extenso"); }

            if (!await VerifyListIsNotEmpty(recetaRequest.ListaIngredienteReceta)) { throw new ExceptionSintaxError("No hay ingredientes en la lista, por favor ingrese al menos uno"); }
            if (!await VerifyListIsNotEmpty(recetaRequest.ListaPasos)) { throw new ExceptionSintaxError("No hay pasos ingresados, por favor ingrese al menos uno"); }

            return true;
        }

        // Validadores de enteros
        private bool VerifyInt(int entero)
        {
            return (int.TryParse(entero.ToString(), out entero));
        }
        private async Task<bool> VerifyRecetaId(Guid recetaId)
        {
            return (await _query.GetRecetaById(recetaId) != null );
        }

        private async Task<bool> VerifyDificultadId(int dificultadId)
        {
           return (await _dificultadService.ValidateDificultadById(dificultadId));
        }
        private async Task<bool> VerifyCategoriaRecetaId(int categoriaRecetaId)
        {
            return (await _categoriaService.ValidateCategoriaRecetaById(categoriaRecetaId));
        }

        // Validadores de strings

        private async Task<bool> VerifyTitleLength(string title)
        {
            return (await _query.GetTitleLength() > title.Length);
        }

        private async Task<bool> VerifyFotoRecetaLenght (string fotoreceta)
        {
            return (await _query.GetFotoRecetaLength() > fotoreceta.Length);
        }
        private async Task<bool> VerifyVideoLenght (string video)
        {
            return (await _query.GetVideoLenght() > video.Length);
        }

        //Validadores de otros microservicios

        //Este tenemos que verlo :D
        //private async Task<bool> VerifyUsuarioId(Guid recetaId)
        //{
        //    throw new NotImplementedException();
        //}

        //Validador de listas

        private Task<bool> VerifyListIsNotEmpty<T>(List<T> lista)
        {
            return Task.FromResult(lista.Count() > 0);
        }

        //Otros
        private Task<TimeSpan> GetHorario(string tiempoPreparacion)
        {
            if (tiempoPreparacion.Length == 5 &&
                int.TryParse(tiempoPreparacion.Substring(0, 2), out int horas) &&
                int.TryParse(tiempoPreparacion.Substring(3, 2), out int minutos) &&
                tiempoPreparacion[2] == ':')
            {
                return Task.FromResult(new TimeSpan(horas, minutos, 0));
            }
            else
            {
                throw new ExceptionSintaxError("Formato erróneo para el horario, pruebe usando hh:mm");
            }
        }


    }
}
