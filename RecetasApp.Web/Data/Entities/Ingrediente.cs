namespace RecetasApp.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Ingrediente : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Ingrediente")]
        public string Ingredient { get; set; }

        public virtual ICollection<RecetaIngrediente> RecetaIngredientes { get; set; }


    }
}
