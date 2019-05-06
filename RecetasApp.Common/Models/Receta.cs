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

        [JsonProperty("imagenUrl")]
        public string ImagenUrl { get; set; }

        [JsonProperty("urlVideo")]
        public object UrlVideo { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("dificultad")]
        public string Dificultad { get; set; }

        [JsonProperty("tiempo")]
        public string Tiempo { get; set; }

        [JsonProperty("temporada")]
        public object Temporada { get; set; }

        [JsonProperty("region")]
        public object Region { get; set; }

        [JsonProperty("pasos")]
        public string Pasos { get; set; }

        [JsonProperty("raciones")]
        public long Raciones { get; set; }

        [JsonProperty("numIngredientes")]
        public long NumIngredientes { get; set; }

        [JsonProperty("medidaIngredientes")]
        public string MedidaIngredientes { get; set; }

        [JsonProperty("ingredientes")]
        public string Ingredientes { get; set; }

        [JsonProperty("observaciones")]
        public object Observaciones { get; set; }

        [JsonProperty("comentarios")]
        public bool Comentarios { get; set; }

        [JsonProperty("publicadaEn")]
        public DateTimeOffset PublicadaEn { get; set; }

        [JsonProperty("stock")]
        public long Stock { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("imageFullPath")]
        public Uri ImageFullPath { get; set; }

        public override string ToString()
        {
            return $"{this.Nombre} {this.Descripcion:C2}";
        }
    }
}
