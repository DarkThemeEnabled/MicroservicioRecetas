﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(RecetasContext))]
    partial class RecetasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CategoriaReceta", b =>
                {
                    b.Property<int>("CategoriaRecetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaRecetaId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoriaRecetaId");

                    b.ToTable("CategoriasReceta", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaRecetaId = 1,
                            Nombre = "Pastas"
                        },
                        new
                        {
                            CategoriaRecetaId = 2,
                            Nombre = "Minutas"
                        },
                        new
                        {
                            CategoriaRecetaId = 3,
                            Nombre = "Ensaladas"
                        },
                        new
                        {
                            CategoriaRecetaId = 4,
                            Nombre = "Pescado"
                        },
                        new
                        {
                            CategoriaRecetaId = 5,
                            Nombre = "Carne"
                        },
                        new
                        {
                            CategoriaRecetaId = 6,
                            Nombre = "Vegetariana"
                        },
                        new
                        {
                            CategoriaRecetaId = 7,
                            Nombre = "Sopas"
                        },
                        new
                        {
                            CategoriaRecetaId = 8,
                            Nombre = "Postres"
                        },
                        new
                        {
                            CategoriaRecetaId = 9,
                            Nombre = "Desayunos"
                        },
                        new
                        {
                            CategoriaRecetaId = 10,
                            Nombre = "Bebidas"
                        },
                        new
                        {
                            CategoriaRecetaId = 11,
                            Nombre = "Aperitivos"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Dificultad", b =>
                {
                    b.Property<int>("DificultadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DificultadId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DificultadId");

                    b.ToTable("Dificultad", (string)null);

                    b.HasData(
                        new
                        {
                            DificultadId = 1,
                            Nombre = "Principiante"
                        },
                        new
                        {
                            DificultadId = 2,
                            Nombre = "Fácil"
                        },
                        new
                        {
                            DificultadId = 3,
                            Nombre = "Media"
                        },
                        new
                        {
                            DificultadId = 4,
                            Nombre = "Díficil"
                        },
                        new
                        {
                            DificultadId = 5,
                            Nombre = "Avanzado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.IngredienteReceta", b =>
                {
                    b.Property<int>("IngredienteRecetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredienteRecetaId"));

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<Guid>("RecetaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.HasKey("IngredienteRecetaId");

                    b.HasIndex("RecetaId");

                    b.ToTable("IngredientesReceta", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Paso", b =>
                {
                    b.Property<int>("PasoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PasoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<Guid>("RecetaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PasoId");

                    b.HasIndex("RecetaId");

                    b.ToTable("Pasos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PromedioPuntaje", b =>
                {
                    b.Property<int>("PromedioPuntajeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromedioPuntajeId"));

                    b.Property<Guid>("RecetaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PromedioPuntajeId");

                    b.HasIndex("RecetaId")
                        .IsUnique();

                    b.ToTable("PromedioPuntajes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Receta", b =>
                {
                    b.Property<Guid>("RecetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoriaRecetaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)");

                    b.Property<int>("DificultadId")
                        .HasColumnType("int");

                    b.Property<string>("FotoReceta")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<TimeSpan>("TiempoPreparacion")
                        .HasColumnType("time");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Topics")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Video")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("RecetaId");

                    b.HasIndex("CategoriaRecetaId");

                    b.HasIndex("DificultadId");

                    b.ToTable("Recetas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.IngredienteReceta", b =>
                {
                    b.HasOne("Domain.Entities.Receta", "Receta")
                        .WithMany("IngredentesReceta")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("Domain.Entities.Paso", b =>
                {
                    b.HasOne("Domain.Entities.Receta", "Receta")
                        .WithMany("Pasos")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("Domain.Entities.PromedioPuntaje", b =>
                {
                    b.HasOne("Domain.Entities.Receta", "Receta")
                        .WithOne("PromedioPuntaje")
                        .HasForeignKey("Domain.Entities.PromedioPuntaje", "RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("Domain.Entities.Receta", b =>
                {
                    b.HasOne("Domain.Entities.CategoriaReceta", "CategoriaReceta")
                        .WithMany("Recetas")
                        .HasForeignKey("CategoriaRecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Dificultad", "Dificultad")
                        .WithMany("Recetas")
                        .HasForeignKey("DificultadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaReceta");

                    b.Navigation("Dificultad");
                });

            modelBuilder.Entity("Domain.Entities.CategoriaReceta", b =>
                {
                    b.Navigation("Recetas");
                });

            modelBuilder.Entity("Domain.Entities.Dificultad", b =>
                {
                    b.Navigation("Recetas");
                });

            modelBuilder.Entity("Domain.Entities.Receta", b =>
                {
                    b.Navigation("IngredentesReceta");

                    b.Navigation("Pasos");

                    b.Navigation("PromedioPuntaje")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
