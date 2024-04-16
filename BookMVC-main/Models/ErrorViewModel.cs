namespace Book_Assignment3.Models // Namespace for the ErrorViewModel class
{
    public class ErrorViewModel // ErrorViewModel class definition
    {
        public string? RequestId { get; set; } // Property to store the request ID (nullable string)

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // Property to determine if the request ID should be shown
    }
}
