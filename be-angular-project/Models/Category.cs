using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace be_angular_project.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; }
        public string CodeCategory { get; set; }
        public string Descriptions { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Product> Products { get; set; }  
    }
}
