namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class RecetaIngrediente : IEntity
    {
        public int Id { get; set; }

        [Required]
        public Receta Receta { get; set; }

        [Required]
        public Ingrediente Ingredientes { get; set; }

        [Required]
        public Medida Medidas { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

    }
}
