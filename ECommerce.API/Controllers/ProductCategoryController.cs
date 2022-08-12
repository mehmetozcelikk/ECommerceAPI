using Business.Abstract;
using Entities.ECommerceDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        [HttpGet("GetProductCategory")]
        public ActionResult GetProductCategory(string? Name,  string? ProductAttributes )
        {
            var data = _productCategoryService.GetProductCategory(Name,  ProductAttributes);
            return Ok(data);
        }
        [HttpPost("CreateProductCategory")]
        public ActionResult CreateProductCategory(ProductCategoryDTO model)
        {
            var data = _productCategoryService.CreateProductCategory(model);
            return Ok(data);
        }
        [HttpGet("DeleteProductCategory")]
        public ActionResult DeleteProductCategory(string Id)
        {
            _productCategoryService.DeleteProductCategory(Id);
            return Ok();
        }
        [HttpPost("UpdateProductCategory")]
        public ActionResult UpdateProductCategory(ProductCategoryDTO model)
        {
            var data = _productCategoryService.UpdateProductCategory(model);
            return Ok(data);
        }
    }
}
