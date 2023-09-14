using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Receta
    {
        public Guid RecetaId { get; set; }
        public int categoriaRecetaId { get; set; }
        public int DificultadId { get; set; }
        public Guid UsuarioId { get; set; }
        public string titulo { get; set; }
        public string FotoReceta { get; set; }
        public string Video { get; set; }
        public TimeSpan TiempoPreparacion { get; set; }
        public ICollection<Paso> Pasos { get; set; }
        public ICollection<IngredienteReceta> IngredentesReceta{ get; set; }

    }
}
