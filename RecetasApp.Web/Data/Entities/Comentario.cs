namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Comentario : IEntity
    {
        public int Id { get; set; }

        public int RecetaId { get; set; }
        public virtual Receta Receta { get; set; }

        public virtual User User { get; set; }

        [Display(Name = "Comentario")]
        public string Comentari { get; set; }
    }
}
