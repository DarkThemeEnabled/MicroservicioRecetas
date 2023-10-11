using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class CategoriaRecetaMapper
    {
        public async Task<CategoriaRecetaResponse> GetCategoriaRecetaResponse (CategoriaReceta categoriaReceta)
        {
            return new CategoriaRecetaResponse
            {
                Id = categoriaReceta.CategoriaRecetaId,
                Nombre = categoriaReceta.Nombre
            };
        }
    }
}
