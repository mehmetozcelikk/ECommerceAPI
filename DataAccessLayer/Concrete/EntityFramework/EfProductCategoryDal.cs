using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductCategoryDal : EfEntityRepositoryBase<ProductCategory, DataContext>, IProductCategoryDal
    {
    }
}
