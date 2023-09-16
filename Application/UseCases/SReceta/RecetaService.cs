﻿using Application.Exceptions;
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
        private readonly IRecetaQuery _recetaQuery;
        private readonly IRecetaCommand _recetaCommand;

        public RecetaService(IRecetaQuery recetaQuery, IRecetaCommand recetaCommand)
        {
            _recetaQuery = recetaQuery;
            _recetaCommand = recetaCommand;
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
                Receta recetaCreada= await _recetaCommand.CreateReceta(receta);
                return new RecetaResponse
                {
                    RecetaId = recetaCreada.RecetaId,
                    CategoriaRecetaId = recetaCreada.CategoriaRecetaId,
                    DificultadId = recetaCreada.DificultadId,
                    UsuarioId = recetaCreada.UsuarioId,
                    Titulo = recetaCreada.Titulo,
                    FotoReceta = recetaCreada.FotoReceta,
                    Video = recetaCreada.Video,
                    TiempoPreparacion = recetaCreada.TiempoPreparacion.ToString()
                };
                //return new ResponseMessage(201, result);  Devolver el statusCode es innecesario ya que lo estamos indicando en el return del controller :)
                //public async Task<ResponseMessage> CreateReceta(RecetaRequest recetaRequest) <--- Devuelve un ResponseMessage que no se utiliza en el controller
            }
            catch (ExceptionSintaxError e)
            {
                throw new ExceptionSintaxError("Error en la sintaxis de la receta a crear: " + e.Message);
            }
            catch (Conflict e)
            {
                throw new Conflict("No se pudo agregar la receta: " + e.Message);
            }


        }

        public async Task<List<RecetaResponse>> GetListRecetas()
        {
            //Después vamos a tener que crear más métodos de búsqueda aparte de este
            //En este caso, no veo la necesidad de realizar un try/catch ya que devuelve una lista con recetas o vacía
            var recetas = await _recetaQuery.GetListRecetas();
            var recetasResponse = new List<RecetaResponse>();

            foreach (var receta in recetas)
            {
                recetasResponse.Add(await CreateResponseReceta(receta));
            }
            return recetasResponse;
        }

        //Métodos privados para RecetaService
        private Task<RecetaResponse> CreateResponseReceta (Receta unaReceta)
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
