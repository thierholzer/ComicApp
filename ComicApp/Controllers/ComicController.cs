using ComicApp.Services;
using Comic.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicApp.Controllers
{
    public class ComicController : Controller
    {
        private ComicBook model;
        private readonly IComicService _service;
        public ComicController(IComicService service)
        {
            model = new ComicBook();
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
            string result = _service.AddNewComic(comic).Result;
            return View(model);
        }
        // GET: Comic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comic/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
