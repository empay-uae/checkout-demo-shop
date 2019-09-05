using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Microsoft.eShopWeb.Web.Pages.Basket
{
    public class SuccessModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ApprovalCode { get; set; }

        public void OnGet()
        {
        }
    }
}