namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class RecetaIngrediente : IEntity
    {
        public int Id { get; set; }

        public int RecetaId { get; set; }
        public virtual Receta Receta { get; set; }


        public int IngredienteId { get; set; }
        public virtual Ingrediente Ingredientes { get; set; }


        public int MedidaId { get; set; }
        public virtual Medida Medidas { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

    }
}
