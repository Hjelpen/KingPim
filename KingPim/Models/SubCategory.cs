using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int VersionNumber { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Category Category { get; set; }
    }
}
