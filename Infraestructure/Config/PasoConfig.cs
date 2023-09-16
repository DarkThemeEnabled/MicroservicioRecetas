using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Config
{
    public class PasoConfig : IEntityTypeConfiguration<Paso>
    {
        public void Configure(EntityTypeBuilder<Paso> entityBuilder)
        {
            entityBuilder.ToTable("Pasos");
            entityBuilder.HasKey(p => p.PasosId);
            entityBuilder.HasOne(r => r.Receta)
                .WithMany(p => p.Pasos)
                .HasForeignKey(r => r.RecetaId);
            entityBuilder.Property(p => p.Descripcion)
                .HasMaxLength(500)
                .IsRequired();
            entityBuilder.Property(p => p.Foto)
                .HasMaxLength(250);
        }
    }
}
