using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class PasoUpdateRequest
    {
        public int id {  get; set; }
        public int Orden { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }

    }
}
