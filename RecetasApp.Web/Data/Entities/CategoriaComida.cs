﻿namespace RecetasApp.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class CategoriaComida : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Categoria de Comida")]
        public string Categoria { get; set; }

    }
}
