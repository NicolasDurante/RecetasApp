namespace RecetasApp.Web.Data.Repositories
{
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRegionRepository : IGenericRepository<Region>
    {
        Task<IQueryable<Region>> GetRegionAsync(string userName);

        IEnumerable<SelectListItem> GetComboRegiones();


    }
}
