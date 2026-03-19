namespace Capstone_LibrarySystem.Models;

public class LibraryManager
{
    private List<LibraryItem> _inventory;
    private List<Loan> _activeLoans = new List<Loan>();

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

    public void BorrowItem(string title, Member member)
    {
        LibraryItem item = FindItemByTitle(title);

        if (item != null && item.Status == ItemStatus.Available)
        {
            item.SetStatus(ItemStatus.OnLoan);
            Loan loan = new Loan(item, member);
            _activeLoans.Add(loan);
            Console.WriteLine($"{title} successfully borrowed by {member.Name}. Due back: {loan.DueDate:dd MMM yyyy}");
        }
        else if (item != null && item.Status == ItemStatus.OnLoan)
        {
            Console.WriteLine("Item is currently checked out.");
        }
        else if (item == null)
        {
            Console.WriteLine("Item not found."); 
        }
        
    }
    
}