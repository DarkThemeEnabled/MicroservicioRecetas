using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IngredienteReceta
    {
        public int IngredienteRecetaId { get; set; }
        public Guid RecetaId { get; set; }
        public Receta Receta { get; set; }
        public int IngredienteId { get; set; }
        public int cantidad { get; set; }
    }
}
