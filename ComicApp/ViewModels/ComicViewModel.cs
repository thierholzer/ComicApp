using Comic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicApp.ViewModels
{
    public class ComicViewModel
    {
        public string ResultsMsg;
        public List<ComicBook> Comics;
        public int SelectedComicId;
        public ComicBook SelectedComic;

        public ComicViewModel()
        {
            Comics = new List<ComicBook>();
            SelectedComic = new ComicBook();
        }
    }
}