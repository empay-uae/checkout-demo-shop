using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class CatalogIndexViewModel
    {
        public IEnumerable<Ad> Ads { get; set; }
        public int? BrandFilterApplied { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<CatalogItemViewModel> CatalogItems { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public int? TypesFilterApplied { get; set; }
    }
}