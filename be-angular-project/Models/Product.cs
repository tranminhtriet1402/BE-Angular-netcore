using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace be_angular_project.Models
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string CodeProduct { get; set; }
        public int? Price { get; set; }
        public string Images { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Descriptions { get; set; }
        public int IdCategory { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual Category IdCategoryNavigation { get; set; }
    }
}
