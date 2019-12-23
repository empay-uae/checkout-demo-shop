using System;
using System.Threading.Tasks;
using Emcredit.Empay.Models;
using Emcredit.Empay.Models.Authorization;
using Emcredit.Empay.Models.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Infrastructure.Identity;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.Pages.Basket;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers.Api
{
    [Route("api/demopayment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _username = null;

        public PaymentController(SignInManager<ApplicationUser> signInManager,
            IBasketViewModelService basketViewModelService,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _basketViewModelService = basketViewModelService;
            _config = config;
        }

        public BasketViewModel BasketModel { get; set; } = new BasketViewModel();

        [Route("create-empay-order")]
        [HttpPost]
        public async Task<IActionResult> CreateEmpayOrderAsync()
        {
            try
            {
                await SetBasketModelAsync();

                var orderRequest = new OrderRequest()
                {
                    Payee = new OrderRequestPayee
                    {
                        BillerId = "123456",
                        DisplayName = "eShop"
                    }
                };

                orderRequest.PurchaseUnits.Add(new OrderRequestPurchaseUnit
                {
                    CustomId = "123456",
                    InvoiceId = "123456",
                    Amount = new AmountWithBreakdown { CurrencyCode = "AED", Value = BasketModel.Total().ToString() }
                });

                // GET Empay API configuration from appsettings.json
                var empayApiEndpoint = new ApiEndpoint();
                _config.Bind("Empay", empayApiEndpoint);

                var orderService = new Emcredit.Empay.OrdersService();

                var result = await orderService.CreateOrderAsync(new CreateOrderInput { Request = orderRequest, EmpayApiEndpoint = empayApiEndpoint })
                    .ConfigureAwait(false);

                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: Handle create order error
                throw;
            }
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