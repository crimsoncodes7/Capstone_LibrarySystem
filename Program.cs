using Capstone_LibrarySystem.Models;
namespace Capstone_LibrarySystem;

class Program
{
    static void Main(string[] args)
    {
        LibraryManager options = new LibraryManager();
        bool validInput;
        int option;
        options.AddItem(new PhysicalBook(0, "1984", "George Orwell", 328));
        options.AddItem(new AudioBook(1, "Dune", "Frank Hubert", 1260));
        while (true)
        {
            do
            {
                Console.WriteLine("--- Library Menu --- \n1. View All Items \n2. Search by Title \n3. Exit");
                Console.Write("Choose Option: ");
                validInput = int.TryParse(Console.ReadLine(), out option);
                Console.Write(validInput ? "" : "Invalid Input. Please enter an integer (1-3).");
            } while (validInput == false);

            switch (option)
            {
                case 1:
                    options.DisplayAllItems();
                    break;
                case 2:
                    Console.WriteLine("What book are you searching for?");
                    string bookTitle = Console.ReadLine();
                    LibraryItem? result = options.FindItemByTitle(bookTitle);
                    if (result != null)  result.DisplayDetails(); 
                    else Console.WriteLine("Item not found."); 
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}