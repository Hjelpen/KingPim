using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models
{
    public class SubCategoryAttributeGroup
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public int AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }

    }
}
