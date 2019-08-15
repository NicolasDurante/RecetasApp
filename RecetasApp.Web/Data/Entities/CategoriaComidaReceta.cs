namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CategoriaComidaReceta : IEntity
    {
        public int Id { get; set; }

        [Required]
        public Receta Receta { get; set; }

        [Required]
        public CategoriaComida CategoriaComida { get; set; }
    }
}
