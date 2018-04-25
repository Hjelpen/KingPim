using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models
{
    public class Product
    {
        public int Id { get; set; }

        [ForeignKey("Subcategory")]
        [JsonIgnore]
        public int SubcategoryId { get; set; }
        [JsonIgnore]
        public SubCategory SubCategory { get; set; }
        public string Name { get; set; }
        public List<AttributeValue> AttributeValue { get; set; }

         //system specific
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int VersionNumber { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
