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
using theObjects.WebAPI.Proxy;
using theObjects.WebAPI.Proxy.ViewModels;

namespace theObjects.Website.Controllers
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

            try
            {
                if (TempData["data"] is string s)
                    pageData = JsonConvert.DeserializeObject<DashboardPageData>(s);
                else
                {
                    var objects = new List<Shape>();

                    objects.AddRange(await Screen<Point>.GetAll());
                    objects.AddRange(await Screen<Circle>.GetAll());
                    objects.AddRange(await Screen<Rectangle>.GetAll());
                    objects.AddRange(await Screen<Square>.GetAll());
                    objects.AddRange(await Screen<Line>.GetAll());

                    pageData = new DashboardPageData()
                    {
                        Objects = objects
                    };
                }

                return View(pageData);
            }
            catch (Exception)
            {
                return View(pageData);
            }
        }

        public async Task<IActionResult> Documents()
        {
            try
            {
                List<Shape> objects = new List<Shape>();

                objects.AddRange(await Screen<Point>.GetAll());
                objects.AddRange(await Screen<Circle>.GetAll());
                objects.AddRange(await Screen<Rectangle>.GetAll());
                objects.AddRange(await Screen<Square>.GetAll());
                objects.AddRange(await Screen<Line>.GetAll());

                var pageData = new DocumentPageData()
                {
                    shapes = objects
                };

                return View("Document", pageData);
            }
            catch (Exception)
            {
                return View("Document", null);
            }
        }

        public async Task<IActionResult> Document(Guid Id, string Type)
        {
            if (Id != Guid.Empty)
            {
                try
                {
                    Shape singleObject = null;

                    switch (Type)
                    {
                        case "Point":
                            singleObject = await Screen<Point>.Get(Id);
                            break;
                        case "Circle":
                            singleObject = await Screen<Circle>.Get(Id);
                            break;
                        case "Rectangle":
                            singleObject = await Screen<Rectangle>.Get(Id);
                            break;
                        case "Square":
                            singleObject = await Screen<Square>.Get(Id);
                            break;
                        case "Line":
                            singleObject = await Screen<Line>.Get(Id);
                            break;
                    }

                    var pageData = new DocumentPageData()
                    {
                        shape = singleObject
                    };

                    return View("Document", pageData);
                }
                catch (Exception)
                {
                    return View("Document", null);
                }

            }
            else
                return View("Document", null);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
