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

        public async Task<ResponseMessage> CreateReceta(RecetaRequest recetaRequest)
        {
            var receta = new Receta
            {
                CategoriaRecetaId = recetaRequest.CategoriaRecetaId,
                DificultadId = recetaRequest.DificultadId,
                UsuarioId = recetaRequest.UsuarioId,
                Titulo = recetaRequest.Titulo,
                FotoReceta = recetaRequest.FotoReceta,
                Video = recetaRequest.Video,
                TiempoPreparacion = recetaRequest.TiempoPreparacion
            };
            await _recetaCommand.CreateReceta(receta);
            var result = new RecetaResponse
            {
                CategoriaRecetaId = recetaRequest.CategoriaRecetaId,
                DificultadId = recetaRequest.DificultadId,
                UsuarioId = recetaRequest.UsuarioId,
                Titulo = recetaRequest.Titulo,
                FotoReceta = recetaRequest.FotoReceta,
                Video = recetaRequest.Video,
                TiempoPreparacion = recetaRequest.TiempoPreparacion
            };
            return new ResponseMessage(201, result);
         
        }

        public async Task<List<RecetaResponse>> GetListRecetas()
        {
            var recetas = await _recetaQuery.GetListRecetas();
            var recetasResponse = new List<RecetaResponse>();

            foreach (var item in recetas)
            {
                var receta = new RecetaResponse
                {
                    RecetaId = item.RecetaId,
                    CategoriaRecetaId = item.CategoriaRecetaId,
                    DificultadId = item.DificultadId,
                    FotoReceta = item.FotoReceta,
                    TiempoPreparacion = item.TiempoPreparacion,
                    Titulo = item.Titulo,
                    Video = item.Video
                };
                recetasResponse.Add(receta);
            }
            return recetasResponse;
        }

        
    }
}
