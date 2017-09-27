using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comic.Data.Models
{
    public class Creator : EntityBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ThumbnailImage { get; set; }
        public List<ComicBook> Comics { get; set; }
    }
}
