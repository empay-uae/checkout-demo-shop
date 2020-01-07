using Emcredit.Empay.Models;
using Emcredit.Empay.Models.Authorization;
using Emcredit.Empay.Models.Orders;
using Emcredit.Empay.Services;
using Flurl.Http;
using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Emcredit.Empay
{
    public class OrdersService : IOrdersService
    {
        public async Task<Order> CreateOrderAsync(CreateOrderInput input)
        {
            return await $"{input.EmpayApiEndpoint.Uri}/ordering/v1/orders"
                .WithOAuthBearerToken(await GetApiAccessTokenAsync(new GetApiAccessTokenInput
                {
                    ApiEndpoint = input.EmpayApiEndpoint,
                    Scope = ApiScopes.AppPermissions.Orders_Create
                }).ConfigureAwait(false))
                .PostJsonAsync(input.Request)
                .ReceiveJson<Order>()
                .ConfigureAwait(false);
        }

        protected static async Task<string> GetApiAccessTokenAsync(GetApiAccessTokenInput input)
        {
            var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = input.ApiEndpoint.TokenEndpoint,
                ClientId = input.ApiEndpoint.ClientId,
                ClientSecret = input.ApiEndpoint.ClientSecret,
                Scope = string.IsNullOrWhiteSpace(input.Scope) ? input.ApiEndpoint.Scope : input.Scope
            });

            if (tokenResponse.IsError)
            {
                throw new Exception($"Failed to get API token. {tokenResponse.Error}");
            }

            return tokenResponse.AccessToken;
        }
    }
}