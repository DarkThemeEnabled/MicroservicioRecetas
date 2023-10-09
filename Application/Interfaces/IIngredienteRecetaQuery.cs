using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIngredienteRecetaQuery
    {
        Task<IngredienteReceta> GetIngRecetaById(int id);
        Task<bool> ExistIngredienteInIngReceta(Guid recetaId, int ingredienteId);
        Task<Guid> GetRecetaIdByIngRecetaId(int ingRecetaId);
        Task<int> GetIngRecetaByRecetaId(Guid recetaId, int ingredienteId);
    }
}
