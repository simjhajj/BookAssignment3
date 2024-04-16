using Microsoft.AspNetCore.Mvc; // Importing necessary namespaces
using System.Text.Encodings.Web; // Importing HtmlEncoder for encoding HTML

namespace Book_Assignment3.Controllers
{
    public class HelloWorldController : Controller // Defining a controller class named HelloWorldController
    {
        // Default action method that returns a string message
        public string Index()
        {
            return "This is the default action! The default Controller method. Always named Index()!";
        }

        // Action method named Welcome that returns a string message
        public string Welcome()
        {
            return "This is the Welcome action method, the other custom Controller method Welcome()";
        }

        // Action method named Info that takes parameters and returns a formatted string message
        public string Info(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}"); // Encoding and returning a formatted string
        }

        // Action method named Verify that takes parameters and returns a formatted string message
        public string Verify(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}"); // Encoding and returning a formatted string
        }
    }
}
