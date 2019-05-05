namespace RecetasApp.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using Data.Entities;
    using System.ComponentModel.DataAnnotations;
    public class RecetaViewModel: Receta
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
