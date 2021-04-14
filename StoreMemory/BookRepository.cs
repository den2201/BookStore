using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreMemory
{
    class BookRepository : IBookRepositoty
    {

        private readonly Book[] books = new[]
        {
          new Book(1, "Art of programming", string.Empty),
          new Book(2, "Refactoring", string.Empty),
          new Book(3, "C programming language", string.Empty),

        };

        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
