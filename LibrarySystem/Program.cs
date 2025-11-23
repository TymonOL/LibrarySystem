using LibrarySystem.Services;


internal class Program
{
    private static void Main(string[] args)
    {
        LibraryService library = new LibraryService();
        library.LoadData();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== SYSTEM BIBLIOTECZNY =====");
            Console.WriteLine("1. Dodaj książkę");
            Console.WriteLine("2. Dodaj czytelnika");
            Console.WriteLine("3. Wypożycz książkę");
            Console.WriteLine("4. Zwróć książkę");
            Console.WriteLine("5. Pokaż wszystkie książki");
            Console.WriteLine("6. Pokaż dostępne książki");
            Console.WriteLine("7. Pokaż czytelników");
            Console.WriteLine("8. Pokaż wypożyczenia");
            Console.WriteLine("9. Zakończ program");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": library.AddBook(); break;
                case "2": library.AddReader(); break;
                case "3": library.BorrowBook(); break;
                case "4": library.ReturnBook(); break;
                case "5": library.ShowAllBooks(); break;
                case "6": library.ShowAvailableBooks(); break;
                case "7": library.ShowReaders(); break;
                case "8": library.ShowLoans(); break;
                case "9":
                    library.SaveData();
                    return;
                default:
                    Console.WriteLine("Niepoprawna opcja!");
                    break;
            }

            Console.WriteLine("\nWciśnij ENTER, aby kontynuować...");
            Console.ReadLine();
        }
    }
}
