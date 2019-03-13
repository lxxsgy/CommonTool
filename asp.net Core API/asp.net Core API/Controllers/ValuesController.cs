using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.ProductService;
using DAL;
using Entity.Table;

namespace asp.net_Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IProductService _productService;

        public ValuesController(IProductService productService)
        {
            _productService = productService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var result = _productService.Test();
            return new string[] { "value1", result };
        }
    }
}
