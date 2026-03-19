namespace Capstone_LibrarySystem.Models;

public abstract class LibraryItem
{
    public int ID { get; }
    public string Title { get; }
    public string Author { get; }
    public ItemStatus Status { get; private set; }

    public LibraryItem(int id, string title, string author)
    {
        this.ID = id;
        this.Title = title;
        this.Author = author;
        Status = ItemStatus.Available;
    }

    public void SetStatus(ItemStatus newStatus)
    {
        Status = newStatus;
    }
    
    public abstract void DisplayDetails();
}