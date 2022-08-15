using Business.Helper.Result;
using Entities.ECommerceDTO;

namespace Business.Abstract
{
    public interface IProductService
    {
        DataResult<ProductDTO> CreateProduct(ProductDTO model);
        DataResult<ProductDTO> UpdateProduct(ProductDTO model);
        DataResult<List<ProductDTO>> GetProduct(string Name, string CategoryName, string ProductAttributes, string PriceRange);
        Result DeleteProduct(string Id);

    }
}
