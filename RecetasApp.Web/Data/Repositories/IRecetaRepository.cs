namespace RecetasApp.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IRecetaRepository : IGenericRepository<Receta>
    {
        IQueryable GetAllWithUsers();
    }

}
