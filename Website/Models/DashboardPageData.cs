using theObjects.WebAPI.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theObjects.Website.Models
{
    public class DashboardPageData
    {
        public List<Product> Products { get; set; }
        public List<Product> Expired { get; set; }
        public bool ProductRemoved { get; set; }
        public string Message { get; set; }
    }
}