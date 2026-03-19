namespace Capstone_LibrarySystem.Models;

public abstract class LibraryItem
{
    public int id { get; private set; }
    public string title { get; private set; }
    public string author { get; private set; }
    public ItemStatus status { get; private set; }

    public LibraryItem(int id, string title, string author)
    {
        this.id = id;
        this.title = title;
        this.author = author;
        status = ItemStatus.Available;
    }

    public abstract void DisplayDetails();
}