namespace RecetasApp.Web.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Models;

    public class RecetaRepository : GenericRepository<Receta>, IRecetaRepository
    {
        private readonly DataContext context;

        public RecetaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public Task AddRegionAsync(AddRegionViewModel model, string userName)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Recetas.Include(r=> r.User);
        }

        
        
    }
}
