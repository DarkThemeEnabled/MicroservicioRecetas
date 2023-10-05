using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class IngredienteRecetaResponse
    {
        //Este tengo que ver cuando haga la conexión con microservicio ignrediente
        public string nombre { get; set; }
        public int ingredienteId { get; set; }
        public int id { get; set; }
        public RecetaResponse receta {get; set;}
    }
}
