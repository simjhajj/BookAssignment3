using Microsoft.AspNetCore.Mvc; // Importing necessary namespaces
using Book_Assignment3.Models; // Importing the Author model
using System.Text.Encodings.Web; // Importing HtmlEncoder for encoding HTML
using System.Xml.Linq; // Importing XDocument for XML processing

namespace Book_Assignment3.Controllers
{
    public class HelloController : Controller // Defining a controller class named HelloController
    {
        // Action method to display the default view
        public IActionResult Index()
        {
            return View(); // Returning a view result
        }

        // Action method to greet the user with a custom message
        public IActionResult Greeting(string name, int numTimes = 1)
        {
            ViewData["Greeting"] = "Hello " + name; // Setting ViewData to include a greeting message with the provided name
            ViewData["Count"] = numTimes; // Setting ViewData to include the number of times to display the greeting

            return View(); // Returning a view result
        }

        // Action method to greet the user with an author's name and a specified number of times
        public IActionResult Author()
        {
            Author author = new Author(); // Creating an instance of the Author class
            string authorName = author.GetName(); // Getting the author's name
            int numTimes = author.GetNumTimes(); // Getting the number of times to greet the author

            ViewData["Greeting"] = "Hello " + authorName; // Setting ViewData to include a greeting message with the author's name
            ViewData["Count"] = numTimes; // Setting ViewData to include the number of times to display the greeting

            return View(); // Returning a view result
        }
    }
}
