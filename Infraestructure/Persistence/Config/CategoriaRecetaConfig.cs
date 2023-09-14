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
    public class CategoriaRecetaConfig : IEntityTypeConfiguration<CategoriasRecetaConfig>
    {
        public void Configure(EntityTypeBuilder<CategoriasRecetaConfig> entityBuilder)
        {
            entityBuilder.ToTable("CategoriasReceta");
            entityBuilder.HasKey(cr => cr.CategoriaRecetaId);
            entityBuilder.HasMany(r => r.Recetas)
                .WithOne(cr => cr.CategoriaReceta);
            entityBuilder.Property(cr => cr.Nombre)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
