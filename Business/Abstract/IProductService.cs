
using Entities.ECommerceDTO;

namespace Business.Abstract
{
    public interface IProductService
    {
        ResultDTO<ProductDTO> CreateProduct(ProductDTO model);
        ResultDTO<ProductDTO> UpdateProduct(ProductDTO model);
        ResultDTO<List<ProductDTO>> GetProduct(string Name, string CategoryName, string ProductAttributes, string PriceRange);
        void DeleteProduct(string Id);

    }
}
