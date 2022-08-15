using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ECommerceDTO
{
    public class ProductCategoryDTO : BaseDTO
    {
        public string Name { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }
        public string? Brand { get; set; }
        public string? ScreenSize { get; set; }
        public string? OS { get; set; }

    }
}
