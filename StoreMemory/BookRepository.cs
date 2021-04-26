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
          new Book(1, "ISBN 234-344-5645","D. Knuth","Art of programming", "Book about programming art", 12m),
          new Book(2, "ISBN 234-4534-56567","Richards", "Refactoring","More information about refactoring", 45.07m),
          new Book(3, "ISBN 345456-2345", "Knuth", "C programming language", "C language info", 7.90m),

        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

      

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return books.Where(book => book.Title.Contains(titleOrAuthor) || book.Author.Contains(titleOrAuthor)).ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
