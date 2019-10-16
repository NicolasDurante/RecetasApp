using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RecetasApp.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRegion();
    }
}