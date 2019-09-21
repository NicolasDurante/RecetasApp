namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class RecetaIngrediente : IEntity
    {
        public int Id { get; set; }

      
        public Receta Receta { get; set; }

   
        public Ingrediente Ingredientes { get; set; }

     
        public Medida Medidas { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

    }
}
