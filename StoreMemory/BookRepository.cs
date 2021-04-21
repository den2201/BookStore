using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreMemory
{
   public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
          new Book(1, "ISBN 234-344-5645","D. Knuth","Art of programming"),
          new Book(2, "ISBN 234-4534-56567","Richards", "Refactoring"),
          new Book(3, "ISBN 345456-2345", "Knuth", "C programming language"),

        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

      

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return books.Where(book => book.Title.Contains(titleOrAuthor) || book.Author.Contains(titleOrAuthor)).ToArray();
        }
    }
}
