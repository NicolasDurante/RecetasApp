namespace RecetasApp.Web.Data
{
    using Entities;
    using RecetasApp.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRecetaRepository : IGenericRepository<Receta>
    {
        IQueryable GetAllWithUsers();

        Task AddRegionAsync(AddRegionViewModel model, string userName);

     


    }

}
