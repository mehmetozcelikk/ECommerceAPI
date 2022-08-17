
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Helper.AutoMapperProfiles;
using Business.Helper.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using ECommerce.API.Controllers;
using Entities.ECommerceDTO;
using Moq;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly IProductService productService;
            private ProductManager ProductService;

        public UnitTest1()
        {


            EfProductDal dal = new EfProductDal();
            EfProductCategoryDal dal2 = new EfProductCategoryDal();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
                cfg.AddProfile(new ProductCategoryProfile());
                cfg.AddProfile(new CustomProductProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ProductService = new ProductManager(dal, dal2, mapper);

        }

        [Fact]
        public void Test1()
        {
            string Name = "test";
            string CategoryName = "111";
            string ProductAttributes = "SS";
            string PriceRange = "1000";

            var result = ProductService.GetProduct(Name, null, null, null);
        }
    }
}

