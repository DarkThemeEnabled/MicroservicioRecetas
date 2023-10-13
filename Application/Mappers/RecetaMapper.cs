using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class RecetaMapper
    {
        private readonly PasoMapper _pasoMapper = new();
        private readonly DificultadMapper _dificultadMapper = new();
        private readonly IngredienteRecetaMapper _ingRecMapper = new();
        private readonly CategoriaRecetaMapper _catRecMapper = new();

        public async Task<RecetaResponse> CreateRecetaResponse(Receta unaReceta)
        {
            var receta = new RecetaResponse
            {
                Id = unaReceta.RecetaId,
                Categoria = await _catRecMapper.GetCategoriaRecetaResponse(unaReceta.CategoriaReceta),
                Dificultad = await _dificultadMapper.GetDificultadResponse(unaReceta.Dificultad),
                FotoReceta = unaReceta.FotoReceta,
                TiempoPreparacion = unaReceta.TiempoPreparacion.ToString(),
                Titulo = unaReceta.Titulo,
                Video = unaReceta.Video,
                pasos = await _pasoMapper.GetListPasosResponse(unaReceta.Pasos),
                ingredientes = await _ingRecMapper.GetIngredientesRecetaResponse(unaReceta.IngredentesReceta)
            };
            return receta;
        }
        public async Task<RecetaDeleteResponse> CreateRecetaDeleteResponse(Receta recetaToDelete)
        {
            return new RecetaDeleteResponse
            {
                id = recetaToDelete.RecetaId,
                titulo = recetaToDelete.Titulo,
            };
        }
    }
}
