using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class IngredienteRecetaRequest
    {
        public int ingredienteId { get; set; }
        public int cantidad { get; set; }
    }
}
