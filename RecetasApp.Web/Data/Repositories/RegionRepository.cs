namespace RecetasApp.Web.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Data.Entities;
    using RecetasApp.Web.Helpers;

    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public RegionRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task<IQueryable<Region>> GetRegionAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this.userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Region;


                    
            }

            return this.context.Regiones;
 
        }
        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = this.context.Regiones.Select(p => new SelectListItem
            {
                Text = p.NomRegion,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(seleccione una region...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboRegiones()
        {
            throw new System.NotImplementedException();
        }
    }
}
