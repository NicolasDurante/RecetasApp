namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class PasosReceta : IEntity
    {
        public int Id { get; set; }

        public Receta Receta { get; set; }

        [Required]
        [Display(Name = "Numero de paso")]
        public int NumPaso { get; set; }

        [Display(Name = "Instrucciones")]
        public string Instrucciones { get; set; }
    }

}
