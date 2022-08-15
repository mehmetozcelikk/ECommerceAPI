using Business.Abstract;
using Entities.Concrete;
using Entities.ECommerceDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProduct")]
        public ActionResult GetProduct(string? Name, string? CategoryName, string? ProductAttributes, string? PriceRange)
        {
            var data =  _productService.GetProduct(Name, CategoryName, ProductAttributes, PriceRange);
            return Ok(data);
        }
        [HttpPost("CreateProduct")]
        public ActionResult CreateProduct(ProductDTO model)
        {
            var data = _productService.CreateProduct(model);
            return Ok(data);
        }
        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(string Id)
        {
            var result = _productService.DeleteProduct(Id);
            return Ok(result);
        }
        [HttpPost("UpdateProduct")]
        public ActionResult UpdateProduct(ProductDTO model)
        {
            var data = _productService.UpdateProduct(model);
            return Ok(data);
        }
    }
}
