namespace RecetasApp.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Receta> Recetas { get; set; }

        public DbSet<Observacion> Observaciones { get; set; }

        public DbSet<PasosReceta> PasosRecetas { get; set; }

        public DbSet<Region> Regiones { get; set; }

        public DbSet<CategoriaComida> CategoriaComidas { get; set; }

        public DbSet<CategoriaComidaReceta> CategoriaComidaRecetas { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<RecetaIngrediente> RecetaIngredientes { get; set; }

        public DbSet<Ingrediente> Ingredientes { get; set; }

        public DbSet<Medida> Medidas { get; set; }


        public object Products { get; internal set; }
        public IQueryable<Region> Region { get; internal set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
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
