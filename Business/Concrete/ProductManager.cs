using AutoMapper;
using Business.Abstract;
using Business.Helper.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ECommerceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IProductCategoryDal _productCategoryDal;
        IMapper _mapper;
        public ProductManager(IProductDal productDal, IProductCategoryDal productCategoryDal, IMapper mapper)
        {
            _productDal = productDal;
            _productCategoryDal = productCategoryDal;
            _mapper = mapper;
        }

        public DataResult<ProductDTO> CreateProduct(ProductDTO model)
        {
            var mapper = _mapper.Map<Product>(model);
            _productDal.Add(mapper);
            return new DataResult<ProductDTO> { Data = model, Success = true };
        }

        public Result DeleteProduct(string Id)
        {
            var deletemodel = _productDal.Get(i => i.Id == Convert.ToInt32(Id));
            deletemodel.IsActive = false;
            _productDal.Update(deletemodel);
            return new Result { Success=true };
        }

        public DataResult<List<ProductDTO>> GetProduct(string Name, string CategoryName, string ProductAttributes, string PriceRange)
        {
            var productvaluedas = _productDal.GetProduct( Name,  CategoryName,  ProductAttributes,  PriceRange);
            var mapper = _mapper.Map<List<ProductDTO>>(productvaluedas);
            return new DataResult<List<ProductDTO>>  { Data = mapper ,Success=true };
        }

        public DataResult<ProductDTO> UpdateProduct(ProductDTO model)
        {
            var mapper = _mapper.Map<Product>(model);
            _productDal.Update(mapper);
            return new DataResult<ProductDTO> { Success = true };

        }
    }
}
