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
using Inventory.WebAPI.Proxy.Models;
using Inventory.WebAPI.Proxy;

namespace Inventory.Website.Controllers
{
    [Authorize]
    public class InsertionController : Controller
    {
        IConfiguration siteConfig;

        public InsertionController(IConfiguration configuration)
        {
            siteConfig = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Insert()
        {
            try
            {
                var name = Request.Form["inputName"].ToString();
                var type = Request.Form["inputType"].ToString();
                var desc = Request.Form["inputDesc"].ToString();
                var weight = Convert.ToInt32(Request.Form["inputWeight"].ToString());
                var price = Convert.ToDecimal(Request.Form["inputPrice"].ToString());

                var dateComps = Request.Form["expiryDate"].ToString().Split('/');
                var expiry = new DateTime(Convert.ToInt32(dateComps[2]), Convert.ToInt32(dateComps[1]), Convert.ToInt32(dateComps[0]));

                var product = new Product()
                {
                    Name = name,
                    InsertionDate = DateTime.Today,
                    ExpiryDate = expiry,
                    Description = desc,
                    Price = price,
                    Weight = weight,
                    Type = type
                };

                List<Product> singleProduct = new List<Product>();

                singleProduct.Add(product);

                var result = await ProductsProxy.SendProducts(singleProduct);

                if (result)
                    return RedirectToAction("Index", "Dashboard");
                else
                    return View("Index");
            }
            catch (Exception exp)
            {
                return View("Index", new DashboardPageData() { Message = exp.Message });
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
