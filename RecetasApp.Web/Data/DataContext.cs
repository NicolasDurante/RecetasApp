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
        public object Products { get; internal set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
