using Application.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRecetaCommand
    {
        Task<Receta> CreateReceta(Receta receta);
        Task<Receta> UpdateReceta(RecetaRequest recetaRequest, Guid recetaId);
       Task<Receta> DeleteReceta(Receta unaReceta);
    }
}
