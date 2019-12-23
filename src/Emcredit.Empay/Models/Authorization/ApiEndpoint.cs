using System;
using System.Collections.Generic;
using System.Text;

namespace Emcredit.Empay.Models.Authorization
{
    public class ApiEndpoint
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string TokenEndpoint { get; set; }
        public string Uri { get; set; }
    }
}