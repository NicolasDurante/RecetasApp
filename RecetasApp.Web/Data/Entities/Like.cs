namespace RecetasApp.Web.Data.Entities
{
    public class Like : IEntity
    {
        public int Id { get; set; }


        public virtual User User { get; set; }

        public int RecetaId { get; set; }
        public virtual Receta Receta { get; set; }
    }
}
