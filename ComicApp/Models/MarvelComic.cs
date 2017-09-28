using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicApp.Models
{
    public class MarvelComic
    {
        public int Id { get; set; }
        public int DigitalId { get; set; }
        public Image Thumbnail { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public double IssueNumber { get; set; }
    }
}