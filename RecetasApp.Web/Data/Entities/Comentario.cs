namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Comentario : IEntity
    {
        public int Id { get; set; }

        public Receta Receta { get; set; }

        public User User { get; set; }

        [Display(Name = "Comentario")]
        public string Comentari { get; set; }
    }
}
