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

namespace BusinessTest
{
    public class UnitTest1
    {
        private readonly IProductService _productService;

        [Fact]
        public void Test1()
        {
            string Name = "test";
            string CategoryName = "111";
            string ProductAttributes = "SS";
            string PriceRange = "1000";

            _productService.GetProduct(Name, CategoryName, ProductAttributes, PriceRange);  
            string Id = "2";


        }
    }
}