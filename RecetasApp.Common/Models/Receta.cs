using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
        public long Raciones { get; set; }

        [JsonProperty("imagenUrl")]
        public string ImagenUrl { get; set; }

        [JsonProperty("urlVideo")]
        public object UrlVideo { get; set; }

        [JsonProperty("temporada")]
        public object Temporada { get; set; }

        [JsonProperty("dificultad")]
        public string Dificultad { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("region")]
        public object Region { get; set; }

        [JsonProperty("comentarios")]
        public bool Comentarios { get; set; }

        [JsonProperty("imageFullPath")]
        public Uri ImageFullPath { get; set; }

        public override string ToString()
        {
            return $"{this.Nombre} {this.Descripcion:C2}";
        }
    }
}
