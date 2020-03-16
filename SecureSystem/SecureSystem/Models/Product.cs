using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public string Specifications { get; set; }
    }
}
