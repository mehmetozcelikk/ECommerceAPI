using Entities.Concrete;
using Entities.ECommerceDTO;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetProduct(string Name, string CategoryName, string ProductAttributes, string PriceRange);

    }
}
