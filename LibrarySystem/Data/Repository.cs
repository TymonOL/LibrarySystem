using LibrarySystem.Models;
using System.Text.Json;

namespace LibrarySystem.Data;

public class Repository
{
    public List<Book> Books { get; private set; } = new();
    public List<Reader> Readers { get; private set; } = new();
    public List<Loan> Loans { get; private set; } = new();

    private const string BooksFile = "books.json";
    private const string ReadersFile = "readers.json";
    private const string LoansFile = "loans.json";

    public void Load()
    {
        if (File.Exists(BooksFile))
            Books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(BooksFile));

        if (File.Exists(ReadersFile))
            Readers = JsonSerializer.Deserialize<List<Reader>>(File.ReadAllText(ReadersFile));

        if (File.Exists(LoansFile))
            Loans = JsonSerializer.Deserialize<List<Loan>>(File.ReadAllText(LoansFile));
    }

    public void Save()
    {
        File.WriteAllText(BooksFile, JsonSerializer.Serialize(Books));
        File.WriteAllText(ReadersFile, JsonSerializer.Serialize(Readers));
        File.WriteAllText(LoansFile, JsonSerializer.Serialize(Loans));
    }
}
