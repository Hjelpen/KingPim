using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Models.ModelViewModels
{
    public class MediaFileGroupViewModel
    {
        public List<MediaFileGroup> MediaFileGroups { get; set; }

        public string Name { get; set; }

        public string ImageAltText { get; set; }

        public MediaType MediaType { get; set; }

        public bool MainImage { get; set; }
    }
}
