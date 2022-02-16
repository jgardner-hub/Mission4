using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext MovieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext data)
        {
            //_logger = logger;
            MovieContext = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts ()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie ()
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieResponse ar)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(ar);
                MovieContext.SaveChanges();

                return View("MovieAdded", ar);
            }
            else
            {
                return View(ar);
            }

        }

        public IActionResult MovieList ()
        {
            var applications = MovieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();



            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var application = MovieContext.Responses.Single(x => x.MovieId == movieid);



            return View("AddMovie", application);
        }
        [HttpPost]
        public IActionResult Edit(AddMovieResponse moovie)
        {
            MovieContext.Update(moovie);
            MovieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var application = MovieContext.Responses.Single(x => x.MovieId == movieid);
            
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(AddMovieResponse am)
        {
            MovieContext.Responses.Remove(am);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
