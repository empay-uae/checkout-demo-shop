using System;
using System.Collections.Generic;
using System.Text;

namespace Emcredit.Empay.Models.Authorization
{
    public class GetApiAccessTokenInput
    {
        public ApiEndpoint ApiEndpoint { get; set; }
        public string Scope { get; set; }
    }
}