using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Entities.ECommerceDTO;

namespace BusinessTest.ProductService
{
    public class ProductServiceTests
    {
        private IProductService productService;
        private IProductCategoryDal _productCategoryDal;
        private IProductDal _productDal;
        private IMapper _mapper;
        public ProductServiceTests(IProductDal productDal, IProductCategoryDal productCategoryDal, IMapper mapper1)
        {
            _productCategoryDal = productCategoryDal;
            _productDal = productDal;
            _mapper = mapper1;
            productService = new ProductManager(_productDal, _productCategoryDal, _mapper);
        }
        [Fact]
        public void GetProduct()
        {
            string Name = "test";
            string CategoryName = "111";
            string ProductAttributes = "SS";
            string PriceRange = "1000";

            var result = productService.GetProduct(Name, null, null, null);

            Assert.NotNull(result);
        }
        [Fact]
        public void DeleteProduct()
        {
            string Id = "2";
            var result = productService.DeleteProduct(Id);

            Assert.Equal(true, result.Success);
        }
        [Fact]
        public void UpdateProduct()
        {
            ProductDTO productDTO = new()
            {
                Id = 2,
                Name = "testupdate",
                ProductCategoryId =2,
                Price = 1000,
                IsActive = true,
            };
            var result = productService.UpdateProduct(productDTO);

            Assert.Equal(true, result.Success);


        }
        [Fact]
        public void CreateProduct()
        {
            ProductDTO productDTO = new()
            {
                Name = "testcreate",
                ProductCategoryId = 2,
                Price = 1000,
                IsActive = true,
            };

            var result = productService.CreateProduct(productDTO);

            var expected = productDTO;
            Assert.Equal(expected, result.Data);
        }
    }
}
