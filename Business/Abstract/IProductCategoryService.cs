using Entities.ECommerceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductCategoryService
    {
        ResultDTO<ProductCategoryDTO> CreateProductCategory(ProductCategoryDTO model);
        ResultDTO<ProductCategoryDTO> UpdateProductCategory(ProductCategoryDTO model);
        ResultDTO<List<ProductCategoryDTO>> GetProductCategory(string Name, string ProductAttributes);
        void DeleteProductCategory(string Id);
    }
}
