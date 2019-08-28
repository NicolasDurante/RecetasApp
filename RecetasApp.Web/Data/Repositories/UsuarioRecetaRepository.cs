namespace RecetasApp.Web.Data.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Data.Entities;
    using RecetasApp.Web.Helpers;

    public class UsuarioRecetaRepository : GenericRepository<Receta>, IUsuarioRecetaRepository
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public UsuarioRecetaRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task<IQueryable<Receta>> GetUsuarioRecetasAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this.userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Recetas
                    
                    
                    .OrderByDescending(o => o.Nombre);
            }

            return this.context.Recetas
                
                .Where(o => o.User == user)
                .OrderByDescending(o => o.Nombre);
        }
    }
}
