using Domain.Entities;
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
        public DbSet<CategoriasRecetaConfig> CategoriasReceta { get; set; }
        public DbSet<Dificultad> Dificultades { get; set; }
        public DbSet<IngredienteReceta> IngredientesRecetas{ get; set; }
        public DbSet<Paso> Pasos{ get; set; }
        public DbSet<PromedioPuntaje> PromediosPuntaje{ get; set; }
        public DbSet<Receta> Recetas{ get; set; }
        public RecetasContext(DbContextOptions<RecetasContext> options)
        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaRecetaConfig());
            modelBuilder.ApplyConfiguration(new DificultadConfig());
            modelBuilder.ApplyConfiguration(new IngredienteRecetaConfig());
            modelBuilder.ApplyConfiguration(new PasoConfig());
            modelBuilder.ApplyConfiguration(new PromedioPuntajeConfig());
            modelBuilder.ApplyConfiguration(new RecetaConfig());
        }
    }
}

