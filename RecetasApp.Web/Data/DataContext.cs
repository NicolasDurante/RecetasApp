namespace RecetasApp.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataContext : DbContext
    {
        public DbSet<Receta> Recetas { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
