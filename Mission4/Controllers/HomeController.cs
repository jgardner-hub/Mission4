﻿using Microsoft.AspNetCore.Mvc;
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
        private MovieContext _MovieContextFile { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext data)
        {
            _logger = logger;
            _MovieContextFile = data;

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
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieResponse ar)
        {
            _MovieContextFile.Add(ar);
            _MovieContextFile.SaveChanges();

            return View("MovieAdded", ar);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
