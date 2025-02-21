using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission6assignment.Models;

namespace mission6assignment.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp) // constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(new Movie());
        }
        [HttpPost]
        public IActionResult NewMovie(Movie entry)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(entry);
                _context.SaveChanges();
                return View("Confirmation", entry); // Redirect to a success page
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(entry);
            }
        }

        public IActionResult ReadMovies()
        {

            if (_context == null)
            {
                Console.WriteLine("Database context is null");
                return View();
            }

            var movies = _context.Movies
                .Include(m => m.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("NewMovie", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {

            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("ReadMovies");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie entry)
        {
            _context.Movies.Remove(entry);
            _context.SaveChanges();

            return RedirectToAction("ReadMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
