using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product :BaseEntity ,IEntity 
    {
        public string Name { get; set; }    
        public float Price { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
