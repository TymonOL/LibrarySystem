namespace LibrarySystem.Models;

public class Loan
{
    public int BookId { get; set; }
    public int ReaderId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}