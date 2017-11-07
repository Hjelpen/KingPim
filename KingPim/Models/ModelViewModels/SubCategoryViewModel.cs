using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models.ModelViewModels
{
    public class SubCategoryViewModel

    {
        public int SubCategoryId { get; set; }

        public string Name { get; set; }

        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int VersionNumber { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<AttributeGroup> AttributeGroups { get; set; }
    }
}
