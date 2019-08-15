namespace RecetasApp.Web.Data
{
    using System.Linq;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class RecetaRepository : GenericRepository<Receta>, IRecetaRepository
    {
        private readonly DataContext context;

        public RecetaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Recetas.Include(r=> r.User);
        }
    }
}
