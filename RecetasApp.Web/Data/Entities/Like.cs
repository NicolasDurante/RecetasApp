namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Like : IEntity
    {
        public int Id { get; set; }

       
        public User User { get; set; }

        public Receta Receta { get; set; }

        


    }
}
