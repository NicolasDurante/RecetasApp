namespace RecetasApp.Web.Models
{
    using Data.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RecetaViewModel : Receta
    {
        //public int RecetaId { get; set; }
        public string UserId { get; set; }

        //public int PasosRecetaId { get; set; }

        //public int NumPaso { get; set; }

        //public string Instrucciones { get; set; }

        public virtual ICollection<PasosReceta> PasosRecetas { get; set; }

        public virtual ICollection<RecetaIngrediente> RecetaIngredientes { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual ICollection<Observacion> Observacions { get; set; }

        public virtual ICollection<CategoriaComidaReceta> CategoriaComidaRecetas { get; set; }

        public virtual ICollection<Like> Likes { get; set; }


        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
