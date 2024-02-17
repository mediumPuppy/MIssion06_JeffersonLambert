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

        public HomeController(MovieContext temp) // constructor
        {
            _context = temp;
            // _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form() { return View(); }

        // some necessary evils
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMovie(Movie response)
        {
            // saving in the db
            _context.Movies.Add(response);
            _context.SaveChanges(); 
            return View("Confirmation", response);
        }
        //for the get to know joel page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }


    }

}
