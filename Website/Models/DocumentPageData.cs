using theObjects.WebAPI.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theObjects.Website.Models
{
    public class DocumentPageData
    {
        public Shape shape { get; set; }
        public List<Shape> shapes { get; set; }
    }
}