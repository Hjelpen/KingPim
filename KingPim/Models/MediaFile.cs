using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models
{
    public class MediaFile
    {
        public int Id { get; set; }
        [ForeignKey("MediaFileGroup")]
        public int MediaFileGroupId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string AltText { get; set; }
        public string GuidName { get; set; }
        public MediaType MediaType { get; set; }
        public bool MainFile { get; set; }
    }
 }

