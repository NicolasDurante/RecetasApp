using Newtonsoft.Json;
using System;

namespace RecetasApp.Common.Models
{
    public class Receta
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("tiempo")]
        public string Tiempo { get; set; }

        [JsonProperty("raciones")]
        public int Raciones { get; set; }

        [JsonProperty("imagenUrl")]
        public object ImagenUrl { get; set; }

        [JsonProperty("temporada")]
        public string Temporada { get; set; }

        [JsonProperty("dificultad")]
        public string Dificultad { get; set; }

        [JsonProperty("actiComentarios")]
        public bool ActiComentarios { get; set; }

        [JsonProperty("numLikes")]
        public int NumLikes { get; set; }

        [JsonProperty("imageFullPath")]
        public object ImageFullPath { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("regionId")]
        public int RegionId { get; set; }

        [JsonProperty("region")]
        public object Region { get; set; }

        [JsonProperty("pasosRecetas")]
        public object PasosRecetas { get; set; }

        [JsonProperty("recetaIngredientes")]
        public object RecetaIngredientes { get; set; }

        [JsonProperty("comentarios")]
        public object Comentarios { get; set; }

        [JsonProperty("observacions")]
        public object Observacions { get; set; }

        [JsonProperty("categoriaComidaRecetas")]
        public object CategoriaComidaRecetas { get; set; }

        [JsonProperty("likes")]
        public object Likes { get; set; }

        public override string ToString()
        {
            return $"{this.Nombre} {this.Descripcion:C2}";
        }
    }
}
