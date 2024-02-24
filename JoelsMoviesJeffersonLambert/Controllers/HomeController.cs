using JoelsMoviesJeffersonLambert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace JoelsMoviesJeffersonLambert.Controllers
{
    public class HomeController : Controller
    {

        // private readonly ILogger<HomeController> _logger;
        // public HomeController(ILogger<HomeController> logger) {
            //_logger = logger;
         //}

        private MovieContext _context;
        private CategoryContext _categoryContext;

        public HomeController(MovieContext temp, CategoryContext temp2) // constructor
        {
            _context = temp;
            _categoryContext = temp2;
            // _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form() 
        {
            ViewBag.IsEditMode = false;
            ViewBag.Categories = _categoryContext.Categories;
            return View(); 
        }

        // some necessary evils
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMovie(Movie response)
        {
            if (ModelState.IsValid) {
            // Check if MovieId is set (assuming default value is 0 or it's nullable)
                if (response.MovieId != null && response.MovieId != 0)
                {
                    int checkId = (int)response.MovieId;

                    bool exists = _context.Movies.Any(m => m.MovieId == checkId);
                    if (exists)
                    {
                        return RedirectToAction("Edit", new { id = checkId });
                    } 
                }

                    // saving in the db
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.IsEditMode = false;
                ViewBag.Categories = _categoryContext.Categories;
                return View("Form");
            }

        }
        //for the get to know joel page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        public IActionResult AllMovies()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMovie(Movie record)
        {
            ViewBag.IsEditMode = false;
            ViewBag.Categories = _categoryContext.Categories;
            _context.Update(record);
            _context.SaveChanges();
            return View("Confirmation", record);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.IsEditMode = true;
            ViewBag.Categories = _categoryContext.Categories;
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            return View("Form", movieToEdit);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var recordToDelete = _context.Movies.Find(id);
            if (recordToDelete != null)
            {
                _context.Movies.Remove(recordToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("AllMovies"); // Replace "Index" with the name of the view you want to redirect to after deletion
        }


    }

}
