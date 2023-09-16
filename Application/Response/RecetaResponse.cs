using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class RecetaResponse
    {
        public Guid RecetaId { get; set; }
        public int CategoriaRecetaId { get; set; }
        public Guid UsuarioId { get; set; }
        public int DificultadId { get; set; }
        public string Titulo { get; set; }
        public string FotoReceta { get; set; }
        public string Video { get; set; }
        public TimeSpan TiempoPreparacion { get; set; }
    }
}
