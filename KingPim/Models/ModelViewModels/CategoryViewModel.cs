using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models.ModelViewModels
{
    public class CategoryViewModel
    {

        public string Name { get; set; }
      
        public Category Category { get; set; }
        public string SubCategoryName { get; set; }

        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int VersionNumber { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
