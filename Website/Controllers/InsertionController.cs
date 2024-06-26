﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using theObjects.Website.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using theObjects.WebAPI.Proxy.ViewModels;
using theObjects.WebAPI.Proxy;

namespace theObjects.Website.Controllers
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

        public async Task<JsonResult> InsertPoint(int X, int Y)
        {
            try
            {
                var result = await Screen<Point>.Draw(new Point(X, Y));

                return Json(result); 
            }
            catch
            {
                return Json(false);
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
