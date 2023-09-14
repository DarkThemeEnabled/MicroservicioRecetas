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
    public class DificultadConfig : IEntityTypeConfiguration<Dificultad>
    {
        public void Configure(EntityTypeBuilder<Dificultad> entityBuilder)
        {
            entityBuilder.ToTable("Dificultad");
            entityBuilder.HasKey(d => d.DificultadId);

            //entityBuilder.HasMany(m => m.ViajeServicios)
            //.WithOne(cm => cm.Servicio)
            //.HasForeignKey(cm => cm.ServicioId);
        }

        //modelBuilder.Entity<Pelicula>()
        //        .HasMany<Funcion>(pel => pel.Funciones)
        //        .WithOne(fun => fun.Pelicula)
        //        .HasForeignKey(fun => fun.PeliculaId)
        //        .IsRequired(false);
        //modelBuilder.ApplyConfiguration(new PeliculasData());
    }
}
