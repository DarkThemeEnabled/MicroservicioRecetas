using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Config
{
    public class PasoConfig : IEntityTypeConfiguration<Paso>
    {
        public void Configure(EntityTypeBuilder<Paso> entityBuilder)
        {
            //entityBuilder.ToTable("Servicio");
            //entityBuilder.HasKey(e => e.ServicioId);

            //entityBuilder.HasMany(m => m.ViajeServicios)
            //.WithOne(cm => cm.Servicio)
            //.HasForeignKey(cm => cm.ServicioId);
        }
    }
}
