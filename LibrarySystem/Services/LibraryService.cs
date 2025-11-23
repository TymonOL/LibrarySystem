using LibrarySystem.Models;
using LibrarySystem.Data;

namespace LibrarySystem.Services;

public class LibraryService
{
    private readonly Repository repo = new();

    public void LoadData() => repo.Load();
    public void SaveData() => repo.Save();

    public void AddBook()
    {
        Console.Write("Tytuł: ");
        string title = Console.ReadLine();

        Console.Write("Autor: ");
        string author = Console.ReadLine();

        Console.Write("Rok wydania: ");
        int year = int.Parse(Console.ReadLine());

        int catalog = repo.Books.Count + 1;

        repo.Books.Add(new Book
        {
            Title = title,
            Author = author,
            Year = year,
            CatalogNumber = catalog,
            IsBorrowed = false
        });

        Console.WriteLine("Dodano książkę!");
    }

    public void AddReader()
    {
        Console.Write("Imię: ");
        string first = Console.ReadLine();

        Console.Write("Nazwisko: ");
        string last = Console.ReadLine();

        int card = repo.Readers.Count + 1;

        repo.Readers.Add(new Reader
        {
            FirstName = first,
            LastName = last,
            CardNumber = card
        });

        Console.WriteLine("Dodano czytelnika!");
    }

    public void BorrowBook()
    {
        Console.Write("Podaj numer katalogowy książki: ");
        int id = int.Parse(Console.ReadLine());

        var book = repo.Books.FirstOrDefault(b => b.CatalogNumber == id);
        if (book == null)
        {
            Console.WriteLine("Nie ma takiej książki!");
            return;
        }

        if (book.IsBorrowed)
        {
            Console.WriteLine("Książka jest już wypożyczona!");
            return;
        }

        Console.Write("Podaj numer karty czytelnika: ");
        int readerId = int.Parse(Console.ReadLine());

        var reader = repo.Readers.FirstOrDefault(r => r.CardNumber == readerId);
        if (reader == null)
        {
            Console.WriteLine("Nie ma takiego czytelnika!");
            return;
        }

        book.IsBorrowed = true;
        repo.Loans.Add(new Loan
        {
            BookId = id,
            ReaderId = readerId,
            BorrowDate = DateTime.Now
        });

        Console.WriteLine("Wypożyczono książkę!");
    }

    public void ReturnBook()
    {
        Console.Write("Podaj numer katalogowy książki do zwrotu: ");
        int id = int.Parse(Console.ReadLine());

        var loan = repo.Loans.FirstOrDefault(l => l.BookId == id && l.ReturnDate == null);

        if (loan == null)
        {
            Console.WriteLine("Ta książka nie jest wypożyczona!");
            return;
        }

        loan.ReturnDate = DateTime.Now;

        var book = repo.Books.First(b => b.CatalogNumber == id);
        book.IsBorrowed = false;

        Console.WriteLine("Książka została zwrócona!");
    }

    public void ShowAllBooks()
    {
        foreach (var b in repo.Books)
        {
            Console.WriteLine($"{b.CatalogNumber}. {b.Title} - {b.Author} ({b.Year}) {(b.IsBorrowed ? "[Wypożyczona]" : "[Dostępna]")}");
        }
    }

    public void ShowAvailableBooks()
    {
        foreach (var b in repo.Books.Where(b => !b.IsBorrowed))
        {
            Console.WriteLine($"{b.CatalogNumber}. {b.Title} - {b.Author}");
        }
    }

    public void ShowReaders()
    {
        foreach (var r in repo.Readers)
        {
            Console.WriteLine($"{r.CardNumber}. {r.FirstName} {r.LastName}");
        }
    }

    public void ShowLoans()
    {
        foreach (var l in repo.Loans)
        {
            string status = l.ReturnDate == null ? "Wypożyczona" : $"Zwrócona {l.ReturnDate}";
            Console.WriteLine($"Książka {l.BookId}, Czytelnik {l.ReaderId}, Data: {l.BorrowDate}, {status}");
        }
    }
}
