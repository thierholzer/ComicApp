using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicApp.Models
{
    public class MarvelComicSearchParam
    {
        public string Format { get; set; }
        public string FormatType { get; set; }
        public string Title { get; set; }
        public string TitleStartsWith { get; set; }
        public int StartYear { get; set; }
        public int IssueNumber { get; set; }

    }
}