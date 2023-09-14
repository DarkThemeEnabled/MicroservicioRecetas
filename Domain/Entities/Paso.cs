using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Paso
    {
        public int PasosId { get; set; }
        public Guid RecetaId { get; set; }
        public Receta Receta { get; set; }
        public int Orden { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
    }
}
