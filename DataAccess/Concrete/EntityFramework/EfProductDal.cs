using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ECommerceDTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, DataContext>, IProductDal
    {
        public List<Product> GetProduct(string Name, string CategoryName, string ProductAttributes, string PriceRange)
        {

            using (var context = new DataContext())
            { 
            IQueryable<Product> query = context.Products;
            query = query.Include(x => x.ProductCategory);

            if (null != Name) 
              query = query.Where(x => x.Name == Name);
            
            if (null != CategoryName)
                query = query.Where(x => x.ProductCategory.Name == CategoryName);

            if (null != ProductAttributes)
            {
                query = query.Where(x => x.ProductCategory.Size == ProductAttributes || x.ProductCategory.Color == ProductAttributes);
            }

            if (null != PriceRange)
                query = query.Where(x => x.Price <= Convert.ToInt64(PriceRange));

            return query.ToList();

            }

            //if (null != ProductAttributes)
            //{
            //    using (var context = new DataContext())
            //    {
            //        var productvalue = context.Products.Include(i => i.ProductCategory).Where(x => x.Name == Name || x.ProductCategory.Name == CategoryName ||
            //                                        x.ProductCategory.Color == ProductAttributes || x.ProductCategory.Size == ProductAttributes
            //                                        || x.Price <= Convert.ToUInt64(PriceRange)).ToList();

            //        return productvalue;
            //    }
            //}

            //using (var context = new DataContext())
            //{
            //    var productvalue = context.Products.Include(i => i.ProductCategory).Where(x => x.Name == Name || x.ProductCategory.Name == CategoryName                                                 
            //                                    || x.Price <= Convert.ToUInt64(PriceRange)).ToList();

            //    return productvalue;
            //}
        }
    }
}
