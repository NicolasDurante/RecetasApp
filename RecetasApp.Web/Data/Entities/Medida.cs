﻿namespace RecetasApp.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medida : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Medida")]
        public string Medid { get; set; }

        [Required]
        public string Abreviacion { get; set; }

        public virtual ICollection<RecetaIngrediente> RecetaIngredientes { get; set; }

    }
}
