using Capstone_LibrarySystem.Models;
namespace Capstone_LibrarySystem;

class Program
{
    static void Main(string[] args)
    {
        List<LibraryItem> books = new List<LibraryItem>();
        
        books.Add(new PhysicalBook(0, "1984", "George Orwell", 328));
        books.Add(new AudioBook(1, "Dune", "Frank Hubert", 1260));

        foreach (LibraryItem book in books)
        {
            book.DisplayDetails();
        }
    }
}