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
        #region Add Comic
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
            //TODO: Add results Msg for Adding a New Comic
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
        #endregion Add Comic

        #region Update Comic

        [HttpGet]
        public ActionResult UpdateComic()
        {
            ComicViewModel cvm = new ComicViewModel();
            cvm.Comics = _service.GetAllComicBooks().Result.ToList();
            return View(cvm);
        }

        [HttpPost]
        public ActionResult UpdateComic(ComicBook SelectedComic)
        {
            ComicViewModel cvm = new ComicViewModel();
            cvm.SelectedComic = _service.UpdateComic(SelectedComic).Result;
            if(cvm.SelectedComic.Id > 0)
            {
                cvm.ResultsMsg = SelectedComic.Name + " has been successfully updated to " + cvm.SelectedComic.Name;
            }
            else
            {
               //ToDo:Error Handling
            }
            cvm.Comics = _service.GetAllComicBooks().Result.ToList();
            return View(cvm);
        }
        #endregion Update Comic

        #region Delete Comic
        [HttpGet]
        public ActionResult DeleteComic()
        {
            ComicViewModel cvm = new ComicViewModel();
            cvm.Comics = _service.GetAllComicBooks().Result.ToList();
            return View(cvm);
        }

        [HttpPost]
        public ActionResult DeleteComic(int SelectedComicId)
        {
            ComicViewModel cvm = new ComicViewModel();
            //ToDo:Validation
            //ToDo: Don't do look up just delete by id.

            if(SelectedComicId > 0)
            {
                ComicBook cb = new ComicBook();
                cb = _service.GetComicBookById(SelectedComicId).Result;
                string result = _service.RemoveComic(cb).Result;

                if(result == System.Net.HttpStatusCode.NoContent.ToString())
                {
                    cvm.ResultsMsg = cb.Name + " has been removed from your collection.";
                }
            }
            return View(cvm);
        }
        #endregion Delete Comic
    }
}
