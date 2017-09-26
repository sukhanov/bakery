using System.Collections.Generic;
using System.Linq;
using Bakery.Services.Interfaces;
using Bakery.Web.Mappers;
using Bakery.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IService _service;

        public ProductController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<WebProductModel> Get()
        {
            var items = _service.GetAllProducts().ToList();
            var mapped = items.Select(ProductMapper.ProductModel2WebProductModel).ToList();
            return mapped;
        }
    }
}