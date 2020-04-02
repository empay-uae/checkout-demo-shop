using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class Ad
    {
        public List<Banner> banners { get; set; }
        public string click_type { get; set; }
        public string click_url { get; set; }
        public string type { get; set; }
    }

    public class Banner
    {
        public string link { get; set; }
        public string resolution { get; set; }
    }

    public class BannerViewModel
    {
        public string message { get; set; }
        public List<Ad> results { get; set; }
        public string status { get; set; }
        public int status_code { get; set; }
        public string txn_id { get; set; }
    }
}