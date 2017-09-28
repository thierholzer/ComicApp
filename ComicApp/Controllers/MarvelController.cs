using ComicApp.Services;
using ComicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicApp.Controllers
{
    public class MarvelController : Controller
    {
        private MarvelViewModel _model = new MarvelViewModel();
        private IComicService _service;
        public MarvelController(IComicService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult SearchMarvel()
        {
            return View(_model);
        }

        [HttpPost]
        public ActionResult SearchMarvel(MarvelViewModel submission)
        {
            _model = submission;
            _model.MarvelComicsList = _service.SearchMarvel(submission.ComicSearchParams).Result.ToList();
            return View(_model);
        }

    }
}