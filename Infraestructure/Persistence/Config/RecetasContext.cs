using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Config
{
    public class RecetasContext : DbContext
    {
        public RecetasContext(DbContextOptions<RecetasContext> options)
        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ServicioConfig());
            //modelBuilder.ApplyConfiguration(new ViajeServicioConfig());
        }
    }
}
