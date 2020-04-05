using Emcredit.Empay.Authorization;
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
        public async Task<CreateOrderRequestResult> CreateOrderAsync(CreateOrderInput input)
        {
            return await $"{input.EmpaySettings.ApiEndpointUrl}/ordering/v1/orders"
                .WithOAuthBearerToken(await GetApiAccessTokenAsync(new GetApiAccessTokenInput
                {
                    EmpaySettings = input.EmpaySettings,
                    Scope = AppPermissions.OrdersWrite
                }).ConfigureAwait(false))
                .PostJsonAsync(input.Request)
                .ReceiveJson<CreateOrderRequestResult>()
                .ConfigureAwait(false);
        }

        protected static async Task<string> GetApiAccessTokenAsync(GetApiAccessTokenInput input)
        {
            var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = input.EmpaySettings.TokenEndpointUrl,
                ClientId = input.EmpaySettings.ClientId,
                ClientSecret = input.EmpaySettings.ClientSecret,
                Scope = string.IsNullOrWhiteSpace(input.Scope) ? input.EmpaySettings.Scope : input.Scope
            });

            if (tokenResponse.IsError)
            {
                throw new Exception($"Failed to get API token. {tokenResponse.Error}");
            }

            return tokenResponse.AccessToken;
        }
    }
}