using BookSystem;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    static void Main(string[] args)
    {
        try
        {
            List<Book> books = new List<Book>();

            // Read book information from the user
            while (true)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    break; // "break" sends the process out of the "while" - stops the loop

                Console.Write("Pages: ");
                int pages = int.Parse(Console.ReadLine()); //parse to transform string to int (ReadLine is always string)

                Console.Write("Publication year: ");
                int year = int.Parse(Console.ReadLine());

                books.Add(new Book(name, pages, year));
            }

            foreach (var book in books)
            {
                log.Info($"{book.Title}, {book.Pages}, {book.PublicationYear}");
                log.Info("TESTE KARINA e FABIO");
                log.Debug("Book TESTE: " + book);
            }

            // Save the books information to a CSV file
            using (StreamWriter writer = new StreamWriter("../../books.csv"))
            {
                foreach (Book book in books)
                {
                    writer.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
                }
            }

            PrintBooks();

            Console.ReadLine();
        }
        catch (Exception e)
        {
            log.Error("Error: " + e.Message);
        }
    }

    private static void PrintBooks()
    {
        // Read book information from the CSV file and print the information
        using (StreamReader reader = new StreamReader("../../books.csv"))
        {
            string line;
            
            // Read user preference for printing
            Console.Write("What information will be printed? ");
            string printType = Console.ReadLine();

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string title = parts[0];
                int pages = int.Parse(parts[1]);
                int publicationYear = int.Parse(parts[2]);

                // Print according to user preference
                if (printType.ToLower() == "everything")
                {
                    Console.WriteLine($"{title}, {pages} pages, {publicationYear}");
                }
                else if (printType.ToLower() == "title")
                {
                    Console.WriteLine($"{title}");
                }
            }
        }
    }
}
