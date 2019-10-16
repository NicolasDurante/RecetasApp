using Microsoft.AspNetCore.Mvc.Rendering;
using RecetasApp.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace RecetasApp.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboRegion()
        {
            /*
            var list = new List<SelectListItem>();
            foreach (var region in _dataContext.Regions)
            {
                list.Add(new SelectListItem 
                {
                    Text = region.NomRegion,
                    Value = $"{region.Id}"
                });
            }
            */
            var list = _dataContext.Regions.Select(r => new SelectListItem
            {
                Text = r.NomRegion,
                Value = $"{r.Id}"
            })
                .OrderBy(r => r.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a pet type...]",
                Value = "0"
            });
            return list;
        }
    }
}
