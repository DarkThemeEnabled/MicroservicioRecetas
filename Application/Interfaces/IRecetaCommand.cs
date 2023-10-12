﻿using Application.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRecetaCommand
    {
        Task<Receta> CreateReceta(Receta receta);
        Task<Receta> UpdateReceta(RecetaRequest recetaRequest, Guid recetaId);
        Task<Receta> DeleteReceta(Receta unaReceta);
    }
}
