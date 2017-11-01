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
    }
}
