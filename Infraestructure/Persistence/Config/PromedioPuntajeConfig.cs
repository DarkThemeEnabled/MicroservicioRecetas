﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Config
{
    public class PromedioPuntajeConfig : IEntityTypeConfiguration<PromedioPuntaje>
    {
        public void Configure(EntityTypeBuilder<PromedioPuntaje> entityBuilder)
        {
            entityBuilder.ToTable("PromedioPuntajes");
            entityBuilder.HasKey(pp => pp.PromedioPuntajeId);
            entityBuilder.HasOne<Receta>(pp => pp.Receta)
                .WithOne(r => r.PromedioPuntaje)
                .HasForeignKey <PromedioPuntaje> (pp => pp.RecetaId)
                .IsRequired();
        }
    }
}
