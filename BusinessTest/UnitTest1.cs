using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Helper.AutoMapperProfiles;
using Business.Helper.Result;
using DataAccess.Abstract;


namespace BusinessTest
{
    public class UnitTest1
    {
        private  IProductService ProductService;

        private IProductCategoryDal _productCategoryDal;
        private IProductDal _productDal;
        private IMapper _mapper;
        public UnitTest1(IProductDal productDal, IProductCategoryDal productCategoryDal, IMapper mapper1)
        {

            _productCategoryDal = productCategoryDal;
            _productDal = productDal;
            _mapper = mapper1;


            ProductService = new ProductManager(_productDal, _productCategoryDal, _mapper);
        }

        [Fact]
        public void Test1()
        {
            string Name = "test";
            string CategoryName = "111";
            string ProductAttributes = "SS";
            string PriceRange = "1000";

            var result = ProductService.GetProduct(Name, null, null, null);
            
            string Id = "2";


        }
    }
}