using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models
{
    public class Category
    {
        
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int VersionNumber { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }

    }
}
