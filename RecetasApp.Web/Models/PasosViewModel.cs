using RecetasApp.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasApp.Web.Models
{
    public class PasosViewModel : PasosReceta
    {
        public int RecetaId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Ingrediente")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a pet type.")]
        public int NumPaso { get; set; }

        public string Instrucciones { get; set; }
    }
}
