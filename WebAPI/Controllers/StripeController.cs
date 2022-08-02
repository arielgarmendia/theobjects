using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Inventory.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.WebAPI.Controllers
{
    [ApiController]
    public class StripeController : Controller
    {
        private IHostingEnvironment _env;

        public StripeController(IHostingEnvironment env)
        {
            _env = env;
        }

        // GET api/products/all
        [HttpGet]
        [Route("api/stripe/callback")]
        public ActionResult<StripeResult> Callback(string code = "test code", string state = "test state")
        {
            try
            {
                return new StripeResult(){ Code = code, State = state };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
