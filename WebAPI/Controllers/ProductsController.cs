using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Inventory.WebAPI.Model;

namespace Inventory.WebAPI.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IHostingEnvironment _env;

        public ProductsController(IHostingEnvironment env)
        {
            _env = env;
        }

        // GET api/products/all
        [HttpGet]
        [Route("api/products/all")]
        public ActionResult<List<Product>> GetAll()
        {
            var product = new Product() { host_path = _env.WebRootPath };

            return product.SelectAll();
        }

        // GET api/products/{name}
        [HttpGet]
        [Route("api/products/{name}")]
        public ActionResult<Product> Get(string name)
        {
            var product = new Product() { host_path = _env.WebRootPath };

            return product.Select(name);
        }

        // POST api/products
        [HttpPost]
        [Route("api/products")]
        public void Send([FromBody]JToken jsonbody)
        {
            List<Product> receivedProducts = JsonConvert.DeserializeObject<List<Product>>(jsonbody.ToString());

            if (receivedProducts.Any())
            {
                foreach (var product in receivedProducts)
                {
                    product.host_path = _env.WebRootPath;

                    if (product.Select(product.Name) != null)
                        product.Update(product, true);
                    else
                        product.Insert(product);
                }
            }
        }

        // POST api/products
        [HttpPost]
        [Route("api/products/delete/{name}")]
        public void DeleteByName(string name)
        {
            var product = new Product() { host_path = _env.WebRootPath };

            product.Delete(name);
        }
    }
}
