namespace Book_Assignment3.Models // Namespace for the Author class
{
    public class Author // Author class definition
    {
        public int Id { get; set; } // Property to store the author's ID

        internal string GetName() // Method to get the author's name (internal for access within the assembly)
        {
            return "Jane Austen"; // Hardcoded name of the author (for demonstration purposes)
        }

        internal int GetNumTimes() // Method to get the number of times the author's name should be displayed (internal for access within the assembly)
        {
            return 5; // Hardcoded number of times (for demonstration purposes)
        }
    }
}