namespace RecetasApp.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using RecetasApp.Web.Data.Entities;


    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Recetas.Any())
            {
                this.AddReceta("Pizza");
                this.AddReceta("Spagetti");
                this.AddReceta("Raviolli");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddReceta(string name)
        {
            this.context.Recetas.Add(new Receta
            {
                Nombre = name,
                Descripcion= "pepe",
                Categoria= "pepe",
                Dificultad= "pepe",
                Tiempo= "pepe",
                Pasos= "pepe",
                Raciones= this.random.Next(100),
                NumIngredientes= this.random.Next(100),
                MedidaIngredientes= "pepe",
                Ingredientes= "pepe",
                Stock = this.random.Next(100)
            });
        }
    }
}
