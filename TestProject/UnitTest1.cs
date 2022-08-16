
using Business.Abstract;
using Business.Concrete;
using Business.Helper.Result;
using ECommerce.API.Controllers;
using Entities.ECommerceDTO;
using Moq;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly IProductService productService;

        public UnitTest1 ( )
        {
        }

        [Fact]
        public void Test1()
        {
            string Name = "test";
            string CategoryName = "111";
            string ProductAttributes = "SS";
            string PriceRange = "1000";
            //ProductController productControllera = new(productService);
            string Id = "2";
            //productControllera.GetProduct(Name,null,null,null);
            //productService.GetProduct(Name, null, null, null);

            var service = new Mock<IProductService>();
            var controller = new ProductController(service.Object);
            var result = controller.GetProduct("test", "111", null, null);
            Assert.NotNull(result);
        }
    }
}

