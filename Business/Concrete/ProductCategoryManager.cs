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
    public class ProductCategoryManager : IProductCategoryService
    {
        IProductCategoryDal _productCategoryDal;
        IProductDal _productDal;
        IMapper _mapper;

        public ProductCategoryManager(IProductCategoryDal productCategoryDal, IMapper mapper, IProductDal productDal)
        {
            _productCategoryDal = productCategoryDal;
            _mapper = mapper;
            _productDal = productDal;
        }

        public ResultDTO<ProductCategoryDTO> CreateProductCategory(ProductCategoryDTO model)
        {
            var mapper = _mapper.Map<ProductCategory>(model);
            _productCategoryDal.Add(mapper);
            return new ResultDTO<ProductCategoryDTO> { Data = model, Success = true };
        }

        public void DeleteProductCategory(string Id)
        {
            ProductCategory productCategory = new();
            productCategory.Id = Convert.ToInt32(Id);
            productCategory.IsActive = false;
            var product =_productDal.GetAll(x => x.Id == Convert.ToInt32(Id));
            //_productDal.DeleteRange(product);
            foreach (var item in product)
            {
                item.IsActive = false;
                _productDal.Update(item);
            }
            _productCategoryDal.Update(productCategory);
        }

        public ResultDTO<List<ProductCategoryDTO>> GetProductCategory(string Name, string ProductAttributes)
        {
            var productvalue = _productCategoryDal.GetAll(x => x.Name == Name  || x.Color == ProductAttributes || x.Size == ProductAttributes);
            var mapper = _mapper.Map<List<ProductCategoryDTO>>(productvalue);
            return new ResultDTO<List<ProductCategoryDTO>> { Data = mapper, Success = true };
        }

        public ResultDTO<ProductCategoryDTO> UpdateProductCategory(ProductCategoryDTO model)
        {
            var mapper = _mapper.Map<ProductCategory>(model);
            _productCategoryDal.Update(mapper);
            return new ResultDTO<ProductCategoryDTO> { Data = model, Success = true };
        }
    }
}
