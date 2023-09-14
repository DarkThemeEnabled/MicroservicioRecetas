using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PromedioPuntaje
    {
        public int PromedioPuntajeId { get; set; }
        public Guid RecetaId { get; set; }
        public Receta Receta { get; set; }

    }
}
