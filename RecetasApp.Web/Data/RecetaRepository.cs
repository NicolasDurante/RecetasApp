namespace RecetasApp.Web.Data
{
    using Entities;
    public class RecetaRepository : GenericRepository<Receta>, IRecetaRepository
    {
        public RecetaRepository(DataContext context) : base(context)
        {

        }
    }
}
