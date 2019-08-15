namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Comentario : IEntity
    {
        public int Id { get; set; }

        [Required]
        public Receta Receta { get; set; }

        [Required]
        public User User { get; set; }

        [Display(Name = "Comentario")]
        public string Comentari { get; set; }
    }
}
