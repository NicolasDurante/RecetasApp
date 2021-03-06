﻿namespace RecetasApp.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Data.Entities;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Receta> Recetas { get; set; }

        public DbSet<Observacion> Observacions { get; set; }

        public DbSet<PasosReceta> PasosRecetas { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<CategoriaComida> CategoriaComidas { get; set; }

        public DbSet<CategoriaComidaReceta> CategoriaComidaRecetas { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<RecetaIngrediente> RecetaIngredientes { get; set; }

        public DbSet<Ingrediente> Ingredientes { get; set; }

        public DbSet<Medida> Medidas { get; set; }

        //public object Receta { get; internal set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }
    }
}
