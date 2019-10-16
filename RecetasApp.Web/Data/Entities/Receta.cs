namespace RecetasApp.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Receta : IEntity
    {
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "El campo {0} only  can contain {1} character length.")]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Tiempo de preparacion")]
        public string Tiempo { get; set; }

        [Required]
        [Display(Name = "Raciones")]
        public int Raciones { get; set; }

        [Display(Name = "Imagen")]
        public string ImagenUrl { get; set; }

        [Display(Name = "Temporada para preparar")]
        public string Temporada { get; set; }

        [Required]
        [Display(Name = "Dificultad de recetas")]
        public string Dificultad { get; set; }

        [Display(Name = "Activar o desactivar Comentarios")]
        public bool ActiComentarios { get; set; }

        [Required]
        [Display(Name = "Numero de Likes")]
        public int NumLikes { get; set; }


        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagenUrl))
                {
                    return null;

                }
                return $"http://192.168.0.11/RecetasApp.Web" + this.ImagenUrl.Substring(1);
            }
        }

        public virtual User User { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<PasosReceta> PasosRecetas { get; set; }

        public virtual ICollection<RecetaIngrediente> RecetaIngredientes { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual ICollection<Observacion> Observacions { get; set; }

        public virtual ICollection<CategoriaComidaReceta> CategoriaComidaRecetas { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
