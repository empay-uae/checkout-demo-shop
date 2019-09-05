using System;
using System.Threading.Tasks;
using Emcredit.Empay;
using Emcredit.Empay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Infrastructure.Identity;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.Pages.Basket;
using Microsoft.eShopWeb.Web.ViewModels.Payment;

namespace Web.Controllers.Api
{
    [Route("api/demopayment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _username = null;

        public PaymentController(SignInManager<ApplicationUser> signInManager, IBasketViewModelService basketViewModelService)
        {
            _signInManager = signInManager;
            _basketViewModelService = basketViewModelService;
        }

        public BasketViewModel BasketModel { get; set; } = new BasketViewModel();

        [Route("create-empay-order")]
        [HttpPost]
        public async Task<IActionResult> CreateEmpayOrderAsync()
        {
            await SetBasketModelAsync();

            var orderRequest = new OrderRequest
            {
                Intent = "CAPTURE",
                PurchaseUnits = new System.Collections.Generic.List<PurchaseUnitRequest>()
            };

            orderRequest.PurchaseUnits.Add(new PurchaseUnitRequest
            {
                CustomId = "123456",
                InvoiceId = "123456",
                Amount = new AmountWithBreakdown { CurrencyCode = "AED", Value = BasketModel.Total().ToString() }
            });

            var orderService = new Emcredit.Empay.OrdersService();

            var result = await orderService.CreateOrderAsync(orderRequest);

            return Ok(result);
        }

        private void GetOrSetBasketCookieAndUserName()
        {
            if (Request.Cookies.ContainsKey(Microsoft.eShopWeb.Web.Constants.BASKET_COOKIENAME))
            {
                _username = Request.Cookies[Microsoft.eShopWeb.Web.Constants.BASKET_COOKIENAME];
            }
            if (_username != null) return;

            _username = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(10);
            Response.Cookies.Append(Microsoft.eShopWeb.Web.Constants.BASKET_COOKIENAME, _username, cookieOptions);
        }

        private async Task SetBasketModelAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(User.Identity.Name);
            }
            else
            {
                GetOrSetBasketCookieAndUserName();
                BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(_username);
            }
        }
    }
}