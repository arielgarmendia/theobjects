using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Inventory.Website.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Inventory.Website.Proxy;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
