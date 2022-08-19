using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ECommerceDTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                query = query.Where(x => x.ProductCategory.Size == ProductAttributes || x.ProductCategory.Color == ProductAttributes);


            if (null != PriceRange) {
                    string[] parts = PriceRange.Split('-');
                    query = query.Where(x => x.Price >= Convert.ToInt64(parts[0]) && x.Price <= Convert.ToInt64(parts[1]));
            }

                //return query.ToList();
            }

            string search = "lookforme";
            List<string> myList = new List<string>();
            string result = myList.Single(s => s == search);

            IEnumerable<string> results = myList.Where(s => s == search);




            string[] parts2 = new string[2];
            if (null != PriceRange)
                parts2 = PriceRange.Split('-');

            using (var context2 = new DataContext())
            {
                var querydeneme = from p in context2.Products.DefaultIfEmpty()
                                  join c in context2.ProductCategories
                                  on p.ProductCategoryId equals c.Id


                                  where null != Name ? p.Name == Name : true
                                  where null != CategoryName ? c.Name == CategoryName : true
                                  where null != ProductAttributes ? (c.Size == ProductAttributes || c.Color == ProductAttributes) : true
                                  where null != PriceRange ? (p.Price >= Convert.ToInt64(parts2[0]) && p.Price <= Convert.ToInt64(parts2[1])) : true

                                  select new Product
                                  {
                                      Name = p.Name,
                                      Price = Convert.ToInt64(p.Price),
                                      ProductCategoryId = p.ProductCategoryId,
                                      ProductCategory = c
                                  };

                return querydeneme.ToList();

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
