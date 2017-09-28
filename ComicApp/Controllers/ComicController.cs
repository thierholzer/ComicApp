using ComicApp.Services;
using Comic.Data.Models;
using ComicApp.ViewModels;
using System.Web.Mvc;
using System.Linq;

namespace ComicApp.Controllers
{
    public class ComicController : Controller
    {
        private ComicBook model = new ComicBook();
        private readonly IComicService _service;
        public ComicController(IComicService service)
        {
            _service = service;

        }
        // GET: Comic
        [HttpGet]
        public ActionResult AddComic()
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult AddComic(ComicBook comic)
        {
            //TODO: Add Server Validation before initiating Save
            string result = _service.AddNewComic(comic).Result;

            if(result != "ERROR")
            {
                model = new ComicBook();
            }
            else
            {
                model = comic;
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult DeleteComic()
        {
            ComicViewModel cvm = new ComicViewModel();
            cvm.Comics = _service.GetAllComicBooks().Result.ToList();
            return View(cvm);
        }

        [HttpPost]
        public ActionResult DeleteComic(ComicViewModel submission)
        {
            if(submission.SelectedComic != null)
            {
                string result = _service.RemoveComic(submission.SelectedComic).Result;
            }
            return View(new ComicViewModel());
        }
    }
}
