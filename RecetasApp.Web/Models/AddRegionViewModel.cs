namespace RecetasApp.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddRegionViewModel
    {
        [Display(Name = "Region")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una region.")]
        public int RegionId { get; set; }


        public IEnumerable<SelectListItem> Regiones { get; set; }
    }
}
