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
    public class DificultadConfig : IEntityTypeConfiguration<Dificultad>
    {
        public void Configure(EntityTypeBuilder<Dificultad> entityBuilder)
        {
            entityBuilder.ToTable("Dificultad");
            entityBuilder.HasKey(d => d.DificultadId);
            entityBuilder.Property(d => d.DificultadId).IsRequired();
            entityBuilder.HasMany(r => r.Recetas);
            entityBuilder.Property(d => d.Nombre).HasMaxLength(50).IsRequired();
        }
    }
}
