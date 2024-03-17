using System;
using System.Collections.Generic;
using System.IO;

class Book
{
    public string Title { get; set; }
    public int Pages { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, int pages, int publicationYear)
    {
        Title = title;
        Pages = pages;
        PublicationYear = publicationYear;
    }

    public override string ToString()
    {
        return $"{Title}, {Pages} pages, {PublicationYear}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>();

        // Read book information from the user
        while (true)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                break;
            Console.Write("Pages: ");
            int pages = int.Parse(Console.ReadLine());
            Console.Write("Publication year: ");
            int year = int.Parse(Console.ReadLine());
            books.Add(new Book(name, pages, year));
        }

        // Write book information to a CSV file
        using (StreamWriter writer = new StreamWriter("books.csv"))
        {
            foreach (Book book in books)
            {
                writer.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
            }
        }

        // Read user preference for printing
        Console.Write("What information will be printed? ");
        string printType = Console.ReadLine();

        // Print according to user preference
        if (printType == "everything")
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
        else if (printType == "title")
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
