namespace Capstone_LibrarySystem.Models;

public class LibraryManager
{
    private List<LibraryItem> _inventory;

    public LibraryManager()
    {
        _inventory = new List<LibraryItem>();
    }

    public void AddItem(LibraryItem item)
    {
        _inventory.Add(item);
    }

    public void DisplayAllItems()
    {
        if (_inventory.Count > 0)
        {
            foreach (var item in _inventory)
            {
                item.DisplayDetails();
            }
        }
        else
        {
            Console.WriteLine("The library is currently empty.");
        }
        
    }

    public LibraryItem? FindItemByTitle(string searchTitle)
    {
        foreach (var item in _inventory)
        {
            if (searchTitle.ToLower() == item.Title.ToLower())
            {
                return item;
            }
        }

        return null;
    }
    
}