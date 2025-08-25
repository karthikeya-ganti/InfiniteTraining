using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_Challenge_9.Models;
using Code_Challenge_9.Repository;

namespace Code_Challenge_9.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository<Movie> _movierepo = null;
        public MovieController()
        {
            _movierepo = new MovieRepository<Movie>();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _movierepo.GetAll();
            return View(movies);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {

                _movierepo.Create(movie);
                _movierepo.Save();
                return RedirectToAction("Index");

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _movierepo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movierepo.Edit(movie);
                _movierepo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _movierepo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _movierepo.Delete(id);
            _movierepo.Save();
            return RedirectToAction("Index");
        }
        public ActionResult ByYear(int year)
        {
            List<Movie> movies = _movierepo.GetAll().Where(m => m.DateofRelease.Year == year).ToList();
            return View("ByYear",movies);
        }

        public ActionResult ByDirector(string name)
        {
            List<Movie> movies = _movierepo.GetAll().Where(m => m.Directorname == name).ToList();
            return View("ByDirector",movies);
        }
    }
}