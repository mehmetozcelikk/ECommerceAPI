using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ECommerceDTO;
using Microsoft.EntityFrameworkCore;
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
            {
                query = query.Where(x => x.ProductCategory.Size == ProductAttributes || x.ProductCategory.Color == ProductAttributes);
            }

            if (null != PriceRange) {
                    string[] parts = PriceRange.Split('-');

                    query = query.Where(x => x.Price >= Convert.ToInt64(parts[0]) && x.Price <= Convert.ToInt64(parts[1]));

                    //query = query.Where(x => x.Price <= Convert.ToInt64(PriceRange));
                }

                //return query.ToList();

            }
            string[] parts2 = new string[2];
            if (null != PriceRange)
               parts2= PriceRange.Split('-');

            using (var context2 = new DataContext())
            {

                var querydeneme = from p in context2.Products.DefaultIfEmpty()
                             join c in context2.ProductCategories
                             on p.ProductCategoryId equals c.Id
                             //join in context2.Products
                             //on c.Id equals c.Id

                             where p.Name == Name ||c.Name == CategoryName  
                             || c.Size == ProductAttributes || c.Color == ProductAttributes 
                             ||(p.Price >= Convert.ToInt64(parts2[0]) && p.Price <= Convert.ToInt64(parts2[1]))
                             where p.IsActive == true 
                             select new Product
                             {
                                 Name = p.Name,
                                 Price = Convert.ToInt64(p.Price),
                                 ProductCategoryId = p.ProductCategoryId,
                                 ProductCategory = c
                             };
                //  IQueryable<Product> deneme2 = context2.Products;
                //var query2 = context2.ProductCategories.Where(i => i.Name == Name);
                //var query3 = context2.Products.Where(i => i.Name == Name);

                //var joinn = deneme2.Join(deneme2,  query2,  i => i.Name == Name, (deneme2,query2)=> new {deneme2 , query2}).Where(o=>o.);
                //var join = query1.Join(query2, x => x.ParentId, y => y.ParentId, (query1, query2) => new { query1, query2 }).Where(o => o.query1.ProdId == o.qyuery2.prodId).......

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
