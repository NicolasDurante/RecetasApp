namespace RecetasApp.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using RecetasApp.Web.Data.Entities;


    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("fer-nicolas-durante@hotmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Nico",
                    LastName = "Durante",
                    Email = "fer-nicolas-durante@hotmail.com",
                    UserName = "fer-nicolas-durante@hotmail.com"
                };

                var result = await this.userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Recetas.Any())
            {
                this.AddReceta("Pizza", user);
                this.AddReceta("Spagetti", user);
                this.AddReceta("Raviolli", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddReceta(string name, User user)
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
                Stock = this.random.Next(100),
                User = user
                
            });
        }
    }
}
