namespace Capstone_LibrarySystem.Models;

public class Loan
{
    public LibraryItem Item { get; }
    public Member Borrower { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }

    public Loan(LibraryItem item, Member borrower)
    {
        Item = item;
        Borrower = borrower;
        BorrowDate = DateTime.Now;
        DueDate = DateTime.Now + TimeSpan.FromDays(14);
    }

    public double CalculateLateFee()
    {
        if (DateTime.Now > DueDate)
        {
            TimeSpan daysLate = DateTime.Now - DueDate;
            double fee = daysLate.Days * 0.50;
            return fee;
        }
        return 0.0;
    }
    
}