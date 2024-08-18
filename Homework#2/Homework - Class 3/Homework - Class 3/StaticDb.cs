using Homework___Class_3.Models;

namespace Homework___Class_3
{
    public static class StaticDB
    {
        public static List<Book> Books = new List<Book>
        {
            new Book { Author = "George Orwell", Title = "1984" },
            new Book { Author = "Harper Lee", Title = "To Kill a Mockingbird" },
            new Book { Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer's Stone" },
            new Book { Author = "F. Scott Fitzgerald", Title = "The Great Gatsby" },
            new Book { Author = "J.R.R. Tolkien", Title = "The Lord of the Rings" }
        };
    }
}
