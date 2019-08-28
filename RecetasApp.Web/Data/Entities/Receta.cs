namespace RecetasApp.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Receta : IEntity
    {
        public int Id { get; set; }

        [MaxLength(200 , ErrorMessage="El campo {0} only  can contain {1} character length.")]
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

        [Display(Name = "Url de Video Adjunto")]
        public string UrlVideo { get; set; }

        [Display(Name = "Temporada para preparar")]
        public string Temporada { get; set; }

        [Required]
        [Display(Name = "Dificultad de recetas")]
        public string Dificultad { get; set; }

        public User User { get; set; }



        public Region Region { get; set; }

        [Display(Name = "Activar o desactivar Comentarios")]
        public bool Comentarios { get; set; }

        [Required]
        [Display(Name = "NumLikes")]
        public int NumLikes { get; set; }



        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagenUrl))
                {
                    return null;

                }
                return $"http://192.168.0.10/RecetasApp.Web" +this.ImagenUrl.Substring(1);
            }
        }
    }
}
