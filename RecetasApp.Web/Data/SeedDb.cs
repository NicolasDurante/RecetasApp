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
            await CheckRegionsAsync();
           
            await CheckCategoriaComidasAsync();
            
           
            
            await CheckIngredientesAsync();
            await CheckMedidasAsync();

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
                var token = await this.userHelper.GenerateEmailConfirmationTokenAsync(user);
                await this.userHelper.ConfirmEmailAsync(user, token);
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

        private async Task CheckMedidasAsync()
        {
            if (!context.Medidas.Any())
            {
                context.Medidas.Add(new Medida { Medid= "Unidades", Abreviacion= "ud.",  });
                context.Medidas.Add(new Medida { Medid = "Gramos", Abreviacion = "gr.", });
                context.Medidas.Add(new Medida { Medid = "Kilos", Abreviacion = "kg.", });
                context.Medidas.Add(new Medida { Medid = "Mililitros", Abreviacion = "ml.", });
                context.Medidas.Add(new Medida { Medid = "Litros", Abreviacion = "lt.", });
                context.Medidas.Add(new Medida { Medid = "Cucharadas", Abreviacion = "cda.", });
                context.Medidas.Add(new Medida { Medid = "Cucharaditas", Abreviacion = "ctda.", });
                context.Medidas.Add(new Medida { Medid = "Pizcas", Abreviacion = "Unid.", });
                context.Medidas.Add(new Medida { Medid = "Tazas", Abreviacion = "tz.", });
                context.Medidas.Add(new Medida { Medid = "Tazas pequeñas", Abreviacion = "tzp.", });
                await context.SaveChangesAsync();
            }
        }

        private async Task CheckIngredientesAsync()
        {
            if (!context.Ingredientes.Any())
            {
                context.Ingredientes.Add(new Ingrediente { Ingredient= "Mantequilla" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Harina" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Tomate" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Vino blanco" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Arroz" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Puerro" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Pan rallado" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Nuez" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Harina fina de maíz" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Vainilla" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Pimentón dulce" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = " Jamón serrano" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Salsa de tomate triturado" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Masa de hojaldre" });
                context.Ingredientes.Add(new Ingrediente { Ingredient = "Jamón cocido" });
                await context.SaveChangesAsync();
            }
        }
        
        private async Task CheckCategoriaComidasAsync()
        {
            if (!context.CategoriaComidas.Any())
            {
                context.CategoriaComidas.Add(new CategoriaComida { Categoria= "Argentinas " });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Dulces " });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Fritas " });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Fáciles " });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Hervidas" });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Latinas" });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Saladas" });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Saludables" });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Vegetarianas" });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "A la Parrilla" });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Al Horno" });
                context.CategoriaComidas.Add(new CategoriaComida { Categoria = "Con Carne" });
  
                await context.SaveChangesAsync();
            }
        }
        
        private async Task CheckRegionsAsync()
        {
            if (!context.Regions.Any())
            {
                context.Regions.Add(new Region { NomRegion = "Mediterraneo" });
                context.Regions.Add(new Region { NomRegion = "Costero" });
                context.Regions.Add(new Region { NomRegion = "Asiatico" });
                context.Regions.Add(new Region { NomRegion = "Arabe" });
                context.Regions.Add(new Region { NomRegion = "Sud America" });
                context.Regions.Add(new Region { NomRegion = "Mediterraneo" });
                await context.SaveChangesAsync();
            }
        }

        private void AddReceta(string name, User user) 
        { 
            this.context.Recetas.Add(new Receta
            {
                Nombre = name,
                Descripcion= "pepe",
                Tiempo= "Media Hora",
                Raciones = this.random.Next(100),
                Dificultad = "Facil",
                Temporada ="Invierno",
                ActiComentarios = true,
                User = user,
                
                
                

            });
        }
    }
}
