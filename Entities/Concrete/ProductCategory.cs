using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductCategory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }
        public string? Brand { get; set; }
        public string? ScreenSize { get; set; }
        public string? OS { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Product { get; set; }



    }
}
