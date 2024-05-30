using theObjects.WebAPI.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theObjects.Website.Models
{
    public class DashboardPageData
    {
        public List<Shape> Objects { get; set; }
        public string Message { get; set; }
    }
}