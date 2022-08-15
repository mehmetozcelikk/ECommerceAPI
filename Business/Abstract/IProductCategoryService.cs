using Business.Helper.Result;
using Entities.ECommerceDTO;

namespace Business.Abstract
{
    public interface IProductCategoryService
    {
        DataResult<ProductCategoryDTO> CreateProductCategory(ProductCategoryDTO model);
        DataResult<ProductCategoryDTO> UpdateProductCategory(ProductCategoryDTO model);
        DataResult<List<ProductCategoryDTO>> GetProductCategory(string Name, string ProductAttributes);
        Result DeleteProductCategory(string Id);
    }
}
