namespace RecetasApp.Web.Data.Entities
{
    public class CategoriaComidaReceta : IEntity
    {
        public int Id { get; set; }

        public int RecetaId { get; set; }
        public virtual Receta Receta { get; set; }

        public virtual CategoriaComida CategoriaComidas { get; set; }


    }
}
