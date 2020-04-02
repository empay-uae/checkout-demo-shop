using Flurl.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogViewModelService _catalogViewModelService;
        private readonly IConfiguration _config;

        public IndexModel(ICatalogViewModelService catalogViewModelService, IConfiguration config)
        {
            _catalogViewModelService = catalogViewModelService;
            _config = config;
        }

        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);

            try
            {
                var bannersResult = await _config["Empay:BannerEndpointUrl"]
               .PostJsonAsync(new
               {
                   txn_id = "14",
                   ad_type = "banner"
               })
               .ReceiveJson<BannerViewModel>()
               .ConfigureAwait(false);

                if (bannersResult != null && bannersResult.status == "success")
                {
                    CatalogModel.Ads = bannersResult.results;
                }
            }
            catch (Exception)
            {
                // TODO: log
            }
        }
    }
}