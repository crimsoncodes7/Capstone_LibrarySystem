namespace Capstone_LibrarySystem.Models;

public class AudioBook : LibraryItem
{
    public int DurationInMinutes { get; }

    public AudioBook(int id, string title, string author, int duration)
        : base(id, title, author)
    {
        DurationInMinutes = duration;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"[Audio] {Title} by {Author} ({DurationInMinutes} mins) - Status: {Status}");
    }
}