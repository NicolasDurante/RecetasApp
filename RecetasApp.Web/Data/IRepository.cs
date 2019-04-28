namespace RecetasApp.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    public interface IRepository
    {
        void AddReceta(Receta receta);

        Receta GetReceta(int id);

        IEnumerable<Receta> GetRecetas();

        bool RecetaExists(int id);

        void RemoveReceta(Receta receta);

        Task<bool> SaveAllAsync();

        void UpdateReceta(Receta receta);
    }
}