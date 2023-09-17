using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRecetaQuery
    {
        Task<List<Receta>> GetListRecetas();
        Task<Receta> GetRecetaById(Guid id);
    }
}
