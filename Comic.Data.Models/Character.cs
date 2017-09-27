using System;
using System.Collections.Generic;

namespace Comic.Data.Models
{
    public class Character : EntityBase
    {
        public string ThumbnailImage { get; set; }
        public List<ComicBook> ComicList { get; set; }

    }
}
