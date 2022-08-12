using AutoMapper;
using Business.Abstract;
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

        public ResultDTO<ProductDTO> CreateProduct(ProductDTO model)
        {
            var mapper = _mapper.Map<Product>(model);
            _productDal.Add(mapper);
            return new ResultDTO<ProductDTO> { Data = model, Success = true };
        }

        public void DeleteProduct(string Id)
        {
            Product product = new();
            product.Id = Convert.ToInt32(Id);
            product.IsActive = false;
            _productDal.Update(product);
        }

        public ResultDTO<List<ProductDTO>> GetProduct(string Name, string CategoryName, string ProductAttributes, string PriceRange)
        {
            var productvaluedas = _productDal.GetProduct( Name,  CategoryName,  ProductAttributes,  PriceRange);
            var mapper = _mapper.Map<List<ProductDTO>>(productvaluedas);
            return new ResultDTO<List<ProductDTO>>  { Data = mapper ,Success=true };
        }

        public ResultDTO<ProductDTO> UpdateProduct(ProductDTO model)
        {
            var mapper = _mapper.Map<Product>(model);
            _productDal.Update(mapper);
            return new ResultDTO<ProductDTO> { Data = model, Success = true };

        }
    }
}
