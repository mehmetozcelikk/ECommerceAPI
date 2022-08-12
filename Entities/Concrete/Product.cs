using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public float Price { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsActive { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
