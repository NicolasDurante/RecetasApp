namespace RecetasApp.Web.Data.Repositories
{
    using Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUsuarioRecetaRepository : IGenericRepository<Receta>
    {
        Task<IQueryable<Receta>> GetUsuarioRecetasAsync(string userName);


    }
}
