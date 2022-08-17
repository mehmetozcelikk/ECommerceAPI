using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Entities.ECommerceDTO;
using Xunit;

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

        [Theory]
        [MemberData(nameof(getDatas))]
        public void GetProductTest(string Name , string CategoryName, string ProductAttributes , string PriceRange)
        {

            var result = productService.GetProduct(Name, null, null, null);

            Assert.NotNull(result.Data);
        }

        [Theory]
        [InlineData("2")]
        public void DeleteProductTest(string Id)
        {
            var result = productService.DeleteProduct(Id);

            Assert.Equal(true, result.Success);
        }

        [Theory]
        [MemberData(nameof(updateDatas))]
        public void UpdateProductTest(int Id ,string name, int productCategoryId, float price, bool IsActive)
        {
            ProductDTO productDTO = new()
            {
                Id = Id,
                Name = "testupdate",
                ProductCategoryId =2,
                Price = 1000,
                IsActive = true,
            };
            var result = productService.UpdateProduct(productDTO);

            Assert.Equal(true, result.Success);
        }

        [Theory]
        [MemberData(nameof(createDatas))]
        public void CreateProductTest(string name, int productCategoryId ,float price, bool IsActive)
        {
            ProductDTO productDTO = new()
            {
                Name = name,
                ProductCategoryId = productCategoryId,
                Price = price,
                IsActive = IsActive,
            };

            var result = productService.CreateProduct(productDTO);

            var expected = productDTO;
            Assert.Equal(productDTO, result.Data);
        }

        public static IEnumerable<object[]> getDatas => new List<object[]> {
         new object[]{ "test", "111", "SS" , "400-600" }
                                             };
        public static IEnumerable<object[]> createDatas => new List<object[]> {
         new object[]{ "testCreate", 2, 1000 , true }
                                             };
        public static IEnumerable<object[]> updateDatas => new List<object[]> {
         new object[]{2, "testUpdate", 2, 1000 , true }
                                             };
    }
}
