using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Entities.ECommerceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Fact]
        public void GetProductCategory()
        {
            string Name = "111";
            string ProductAttributes = "SS";
            var result = productCategoryService.GetProductCategory(Name , ProductAttributes);
            Assert.NotNull(result);
        }
        [Fact]
        public void DeleteProductCategory()
        {
            string Id = "11";
            var result = productCategoryService.DeleteProductCategory(Id);

            Assert.Equal(true, result.Success);
        }
        [Fact]
        public void UpdateProductCategory()
        {
            ProductCategoryDTO productCategoryDTO = new()
            {
                Id =  11 ,
                Name = "testupdate",
                Size = "testSizeupdate",
                Color = "testColorupdate",
                ScreenSize = "testScreensizeupdate",
                Gender = "testGenderupdate",
                OS = "testOSupdate",
                Brand= "testBrandupdate",
                IsActive = true,
            };
            var result = productCategoryService.UpdateProductCategory(productCategoryDTO);

            Assert.Equal(true, result.Success);

        }
        [Fact]
        public void CreateProductCategory()
        {
            ProductCategoryDTO productCategoryDTO = new()
            {
                Name = "testCreate",
                Size = "testSizeCreate",
                Color = "testColorCreate",
                ScreenSize = "testScreensizeCreate",
                Gender = "testGenderCreate",
                OS = "testOSCreate",
                Brand = "testBrandCreate",
                IsActive = true,
            };
            var result = productCategoryService.CreateProductCategory(productCategoryDTO);
            var expected = productCategoryDTO;
            Assert.Equal(expected, result.Data);

        }
    }
}
