using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ECommerceDTO
{
    public class ProductDTO :BaseDTO
    {
        public string Name { get; set; }    
        public float Price { get; set; }
        public int ProductCategoryId { get; set; }

        public ProductCategoryDTO ProductCategoryDTO { get; set; }
    }
}
