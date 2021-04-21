using System;
using System.Collections.Generic;
using System.Text;

namespace store
{
    public class BookService
    {

        private readonly IBookRepository bookRepositoty;

        public BookService(IBookRepository bookRepositoty)
        {
            this.bookRepositoty = bookRepositoty;
        }

        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return bookRepositoty.GetAllByIsbn(query);
            else
                return bookRepositoty.GetAllByTitleOrAuthor(query);
        }


    }
}
