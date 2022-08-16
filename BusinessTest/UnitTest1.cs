using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Helper.Result;
using DataAccess.Abstract;
using ECommerce.API.Controllers;
using Entities.Concrete;
using Entities.ECommerceDTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Xml.Linq;

namespace BusinessTest
{
    public class UnitTest1
    {
        private readonly IProductService _productService;
          IProductDal productDal;
          IProductCategoryDal productCategoryDal;
          IMapper mapper;
        public UnitTest1(
        //IProductService productService,
        //IProductDal productDal,
        //IProductCategoryDal productCategoryDal,
        //IMapper mapper
            )
        {

            _productService = new ProductManager(productDal, productCategoryDal, mapper);

        }

        [Fact]
        public void Test1()
        {
            string Name = "test";
            string CategoryName = "111";
            string ProductAttributes = "SS";
            string PriceRange = "1000";

            var result =_productService.GetProduct(Name, CategoryName, ProductAttributes, PriceRange);
            string Id = "2";


        }
    }
}