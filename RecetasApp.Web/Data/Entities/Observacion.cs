namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Observacion : IEntity
    {
        public int Id { get; set; }

        public int RecetaId { get; set; }
        public virtual Receta Receta { get; set; }

        [Display(Name = "Observacion")]
        public string Observacio { get; set; }







    }
}
