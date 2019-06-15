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

        [Display(Name = "Imagen")]
        public string ImagenUrl { get; set; }

        [Display(Name = "Url de Video Adjunto")]
        public string UrlVideo { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required]
        [Display(Name = "Dificultad de recetas")]
        public string Dificultad { get; set; }

        [Required]
        [Display(Name = "Tiempo de preparacion")]
        public string Tiempo { get; set; }

        
        [Display(Name = "Temporada para preparar")]
        public string Temporada { get; set; }

        
        [Display(Name = "Region de receta")]
        public string Region { get; set; }

        [Required]
        [Display(Name = "Pasos")]
        public string Pasos { get; set; }

        [Required]
        [Display(Name = "Raciones")]
        public int Raciones { get; set; }

        [Required]
        [Display(Name = "Numero de Ingredientes o medidas"), DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public int NumIngredientes { get; set; }

        [Required]
        [Display(Name = "Tipo de medidas ")]
        public string MedidaIngredientes { get; set; }

        [Required]
        [Display(Name = "Ingredientes")]
        public string Ingredientes { get; set; }

        [Display(Name = "Observaciones o Info. extra")]
        public string Observaciones { get; set; }

        [Display(Name = "Activar o desactivar Comentarios")]
        public bool Comentarios { get; set; }
         
        [Display(Name = "Fecha de publicacion")]
        public DateTime PublicadaEn { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        public User User { get; set; }

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
