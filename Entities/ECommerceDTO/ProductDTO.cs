using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ECommerceDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public float Price { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsActive { get; set; }
        public ProductCategoryDTO ProductCategoryDTO { get; set; }
    }
}
