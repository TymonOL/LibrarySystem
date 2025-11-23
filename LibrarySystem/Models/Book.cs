namespace LibrarySystem.Models;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int CatalogNumber { get; set; }
    public bool IsBorrowed { get; set; }
}