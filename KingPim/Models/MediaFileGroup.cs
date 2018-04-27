using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models
{
    public class MediaFileGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MediaFile> MediaFile { get; set; }

        public virtual Product Product { get; set; }

        //system specific
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public int VersionNumber { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
