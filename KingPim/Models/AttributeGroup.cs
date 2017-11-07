using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models
{
    public class AttributeGroup
    {
        [Required]
        public string AttributeGroupName { get; set; }
        [Key]
        public int AttributeGroupId { get; set; }

        public ICollection<SubCategoryAttributeGroup> SubCategoryAttributeGroups { get; set; }
    }
        
}
