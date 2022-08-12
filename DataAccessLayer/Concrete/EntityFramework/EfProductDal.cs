using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ECommerceDTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, DataContext>, IProductDal
    {
        public List<Product> GetProduct(string Name, string CategoryName, string ProductAttributes, string PriceRange)
        {
            {
                using (var context = new DataContext())
                {
                    var productvalue = context.Products.Include(i => i.ProductCategory).Where(x => x.Name == Name || x.ProductCategory.Name == CategoryName ||
                                                    x.ProductCategory.Color == ProductAttributes || x.ProductCategory.Size == ProductAttributes).ToList();

                    return productvalue;
                }
            }
        }
    }
}
