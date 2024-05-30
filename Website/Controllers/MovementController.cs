using System;
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
    public class MovementController : Controller
    {
        IConfiguration siteConfig;

        public MovementController(IConfiguration configuration)
        {
            siteConfig = configuration;
        }

        public async Task<IActionResult> Index(Guid Id, string Type)
        {
            ViewBag.Id = Id;

            if (Type == "Point")
            {
                var result = await Screen<Point>.Get(Id);

                if (result != null)
                {
                    ViewBag.X = result.X;
                    ViewBag.Y = result.Y;
                }
                else
                {
                    ViewBag.X = 0;
                    ViewBag.Y = 0;
                }
            }

            return View();
        }

        public async Task<JsonResult> MovePoint(Guid Id, int X, int Y)
        {
            try
            {
                var result = await Screen<Point>.Move(Id, X, Y);

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
