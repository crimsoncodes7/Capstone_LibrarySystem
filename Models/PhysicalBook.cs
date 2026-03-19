namespace Capstone_LibrarySystem.Models;

public class PhysicalBook : LibraryItem
{
    public int Pages { get; }

    public PhysicalBook(int id, string title, string author, int pages)
        : base(id, title, author)
    {
        this.Pages = pages;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"[Book] {Title} by {Author} ({Pages} pages) - Status: {Status}");
    }
}