namespace RecetasApp.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Entities;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            var user = await this.userHelper.GetUserByEmailAsync("fer-nicolas-durante@hotmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Nico",
                    LastName = "Durante",
                    Email = "fer-nicolas-durante@hotmail.com",
                    UserName = "fer-nicolas-durante@hotmail.com"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
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
