namespace RecetasApp.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<Receta> GetRecetas()
        {
            return this.context.Recetas.OrderBy(r => r.Nombre);
        }

        public Receta GetReceta(int id)
        {
            return this.context.Recetas.Find(id);
        }

        public void AddReceta(Receta receta)
        {
            this.context.Recetas.Add(receta);
        }

        public void UpdateReceta(Receta receta)
        {
            this.context.Recetas.Update(receta);
        }

        public void RemoveReceta(Receta receta)
        {
            this.context.Recetas.Remove(receta);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool RecetaExists(int id)
        {
            return this.context.Recetas.Any(r => r.Id == id);
        }

    }
}
