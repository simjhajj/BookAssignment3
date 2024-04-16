using Microsoft.AspNetCore.Mvc; // Importing necessary namespaces
using Book_Assignment3.Models; // Importing the ErrorViewModel
using System.Diagnostics; // Importing the Diagnostic namespace for debugging

namespace Book_Assignment3.Controllers
{
    public class HomeController : Controller // Defining a controller class named HomeController
    {
        private readonly ILogger<HomeController> _logger; // Declaring a private readonly field of type ILogger

        // Constructor to initialize the HomeController with ILogger dependency injection
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // Initializing the ILogger field
        }

        // Action method to display the Index view
        public IActionResult Index()
        {
            return View(); // Returning the Index view result
        }

        // Action method to display the Privacy view
        public IActionResult Privacy()
        {
            return View(); // Returning the Privacy view result
        }

        // Action method to handle errors and display the Error view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Specifies caching behavior
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            // Returning the Error view result with an instance of ErrorViewModel
        }
    }
}
