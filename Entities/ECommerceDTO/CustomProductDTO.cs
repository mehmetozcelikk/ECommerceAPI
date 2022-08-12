using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ECommerceDTO
{
    public class CustomProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }
        public string? Brand { get; set; }
        public string? ScreenSize { get; set; }
        public string? OS { get; set; }
    }
}
