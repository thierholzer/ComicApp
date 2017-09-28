using Comic.Data.Models;
using ComicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicApp.ViewModels
{
    public class MarvelViewModel
    {
        public List<string> ComicFormatOptions { get; set; }
        public List<string> ComicFormatType { get; set; }
        public MarvelComicSearchParam ComicSearchParams { get; set; }
        public List<MarvelComic> MarvelComicsList { get; set; }

        public MarvelViewModel()
        {
            ComicFormatOptions = new List<string>()
            {
                "","comic","magazine","trade paperback", "hardcover", "digest", "graphic novel", "digital comic","infinite comic"
            };
            ComicFormatType = new List<string>()
            {
                "","comic", "collection"
            };
            ComicSearchParams = new MarvelComicSearchParam();
            MarvelComicsList = new List<MarvelComic>();
        }
    }
}