namespace RecetasApp.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Receta
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public string ImagenUrl { get; set; }

        [Display(Name = "Url de Video Adjunto")]
        public string UrlVideo { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Display(Name = "Dificultad de recetas")]
        public string Dificultad { get; set; }

        [Display(Name = "Tiempo de preparacion")]
        public string Tiempo { get; set; }

        [Display(Name = "Temporada para preparar")]
        public string Temporada { get; set; }

        [Display(Name = "Region de receta")]
        public string Region { get; set; }

        [Display(Name = "Pasos")]
        public string Pasos { get; set; }

        [Display(Name = "Raciones")]
        public int Raciones { get; set; }

        [Display(Name = "Numero de Ingredientes o medidas"), DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public int NumIngredientes { get; set; }

        [Display(Name = "Tipo de medidas ")]
        public string MedidaIngredientes { get; set; }

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

    }
}
