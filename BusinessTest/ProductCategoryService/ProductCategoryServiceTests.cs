using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Entities.ECommerceDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessTest.ProductCategoryService
{
    public class ProductCategoryServiceTests
    {
        private IProductService productService;
        private IProductCategoryService productCategoryService;
        private IProductCategoryDal _productCategoryDal;
        private IProductDal _productDal;
        private IMapper _mapper;
        public ProductCategoryServiceTests(IProductDal productDal, IProductCategoryDal productCategoryDal, IMapper mapper1)
        {
            _productCategoryDal = productCategoryDal;
            _productDal = productDal;
            _mapper = mapper1;
            productService = new ProductManager(_productDal, _productCategoryDal, _mapper);
            productCategoryService = new ProductCategoryManager(_productDal, _productCategoryDal, _mapper);

        }

        [Theory]
        [MemberData(nameof(getDatas))]
        public void GetProductCategoryTest(string Name ,string ProductAttributes)
        {

            var result = productCategoryService.GetProductCategory(Name , ProductAttributes);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("2")]
        public void DeleteProductCategoryTest(string Id)
        {
            var result = productCategoryService.DeleteProductCategory(Id);

            Assert.Equal(true, result.Success);
        }

        [Theory]
        [MemberData(nameof(updateDatas))]
        public void UpdateProductCategoryTest(int Id ,string Name, string Size, string Color, string ScreenSize, string Gender, string OS, string Brand, bool IsActive)
        {
            ProductCategoryDTO productCategoryDTO = new()
            {
                Id =  Id ,
                Name = Name,
                Size = Size,
                Color = Color,
                ScreenSize = ScreenSize,
                Gender = Gender,
                OS = OS,
                Brand = Brand,
                IsActive = IsActive,
            };
            var result = productCategoryService.UpdateProductCategory(productCategoryDTO);

            Assert.Equal(true, result.Success);
        }

        [Theory]
        [MemberData(nameof(createDatas) )]
        public void CreateProductCategoryTest(string Name , string Size , string Color , string ScreenSize , string Gender , string OS , string Brand , bool IsActive)
        {
            ProductCategoryDTO productCategoryDTO = new()
            {
                Name = Name,
                Size = Size,
                Color = Color,
                ScreenSize = ScreenSize,
                Gender = Gender,
                OS = OS,
                Brand = Brand,
                IsActive = IsActive,
            };
            var result = productCategoryService.CreateProductCategory(productCategoryDTO);
            var expected = productCategoryDTO;
            Assert.Equal(expected, result.Data);
        }

        public static IEnumerable<object[]> getDatas => new List<object[]> {
         new object[]{  "111", "SS" }
                                             };
        public static IEnumerable<object[]> createDatas => new List<object[]> {
         new object[]{ "testCreate", "testSizeCreate", "testColorCreate" , "testScreensizeCreate" , "testGenderCreate" , "testOSCreate" , "testBrandCreate" ,true }
                                             };
        public static IEnumerable<object[]> updateDatas => new List<object[]> {
         new object[]{2, "testUpdate", "testSizeUpdate", "testColorUpdate", "testScreensizeUpdate", "testGenderUpdate", "testOSUpdate", "testBrandUpdate", true }
                                             };

    }
}
