namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CategoriaComidaReceta : IEntity
    {
        public int Id { get; set; }

        public Receta Receta { get; set; }

        public CategoriaComida CategoriaComidas { get; set; }


    }
}
