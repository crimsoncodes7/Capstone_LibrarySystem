using System;
using System.IO;
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

    public void ReturnItem(string title)
    {
        LibraryItem item = FindItemByTitle(title);

        if (item == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }
        else if (item.Status == ItemStatus.Available)
        {
            Console.WriteLine("This item isn't on loan. Please enter a different title.");
            return;
        }
        
        foreach (Loan loan in _activeLoans)
        {
            if (loan.Item == item)
            {
                double fee = loan.CalculateLateFee();

                if (fee > 0)  Console.WriteLine($"Item returned late! Fee due: £{fee:C2}");
                else Console.WriteLine("Item returned on time. Thank you!");
                item.SetStatus(ItemStatus.Available);
                _activeLoans.Remove(loan);
                break;
            }
        }
    }

    public void SaveDatabase()
    {
        using (StreamWriter sw = new StreamWriter(File.Open("library_db.txt", FileMode.Create)))
        {
            foreach (var item in _inventory)
            {
                if (item is PhysicalBook pb) 
                {
                    sw.WriteLine($"Book,{pb.ID},{pb.Title},{pb.Author},{pb.Pages},{pb.Status}");
                }
                else if (item is AudioBook ab)
                {
                    sw.WriteLine($"Audio,{ab.ID},{ab.Title},{ab.Author},{ab.DurationInMinutes},{ab.Status}");
                }
            }
        }
    }

    public void LoadDatabase()
    {
        if (File.Exists("library_db.txt"))
        {
            _inventory.Clear();
            using (StreamReader sr = new StreamReader("library_db.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(',');
                    if (parts[0] == "Book")
                    {
                        LibraryItem item = new PhysicalBook(int.Parse(parts[1]), parts[2], parts[3], int.Parse(parts[4]));
                        item.SetStatus(Enum.Parse<ItemStatus>(parts[5]));
                        _inventory.Add(item);
                    }
                    else if (parts[0] == "Audio")
                    {
                        LibraryItem item = new AudioBook(int.Parse(parts[1]), parts[2], parts[3], int.Parse(parts[4]));
                        item.SetStatus(Enum.Parse<ItemStatus>(parts[5]));
                        _inventory.Add(item);
                    }
                    
                }
            }
        }
        else return;
    }
}