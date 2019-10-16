namespace RecetasApp.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Region : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de Region")]
        public string NomRegion { get; set; }

        public virtual ICollection<Receta> Recetas { get; set; }

    }
}
