using RecetasApp.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasApp.Web.Controllers.API
{
    public class PasosRecetaResponce
    {
        public int Id { get; set; }

        public int RecetaId { get; set; }

        public virtual string Receta { get; set; }

        [Required]
        [Display(Name = "Numero de paso")]
        public int NumPaso { get; set; }

        [Display(Name = "Instrucciones")]
        public string Instrucciones { get; set; }
    }
}
