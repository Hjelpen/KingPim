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

        public int CategoryID { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }
}
