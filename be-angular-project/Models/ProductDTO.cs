using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace be_angular_project.Models
{
    public class ProductDTO
    {
        public bool success { get; set; }
        public string message { get; set; }
        public ICollection<Product> product { get; set; }
        public int total { get; set; }
    }
}
