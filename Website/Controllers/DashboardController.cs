using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Inventory.Website.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Inventory.WebAPI.Proxy;
using Inventory.WebAPI.Proxy.Models;

namespace Inventory.Website.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        IConfiguration siteConfig;

        public DashboardController(IConfiguration configuration)
        {
            siteConfig = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var pageData = new DashboardPageData();

            if (TempData["data"] is string s)
                pageData = JsonConvert.DeserializeObject<DashboardPageData>(s);
            else
            {
                var products = await ProductsProxy.GetProducts();

                var expired = new List<Product>();

                foreach (var item in products)
                    if (item.ExpiryDate <= DateTime.Today)
                        expired.Add(item);

                pageData = new DashboardPageData()
                {
                    Products = products,
                    Expired = expired
                };
            }

            return View(pageData);
        }

        public async Task<IActionResult> Document(string Id)
        {
            if (Id != "")
            {
                var singleProduct = await ProductsProxy.GetProduct(Id);

                return View("Document", singleProduct);
            }
            else
                return View("Document", null);
        }

        public async Task<IActionResult> Remove(string Id)
        {
            var deleted = false;

            if (Id != "")
                deleted = await ProductsProxy.DeleteProduct(Id);

            var products = await ProductsProxy.GetProducts();

            var expired = new List<Product>();

            foreach (var item in products)
                if (item.ExpiryDate <= DateTime.Today)
                    expired.Add(item);

            var pageData = new DashboardPageData()
            {
                Products = products,
                Expired = expired,
                ProductRemoved = deleted
            };

            var s = Newtonsoft.Json.JsonConvert.SerializeObject(pageData);

            TempData["data"] = s;

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
