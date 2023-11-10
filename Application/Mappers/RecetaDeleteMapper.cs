using Application.Interfaces.Mappers;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class RecetaDeleteMapper: IRecetaDeleteMapper
    {
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
