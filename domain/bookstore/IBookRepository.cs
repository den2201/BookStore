using System;
using System.Collections.Generic;
using System.Text;

namespace store
{
    public interface IBookRepository
    {

        Book GetById(int id);

        Book[] GetAllBooksById(IEnumerable<int> idList);

        Book[] GetAllByIsbn(string isbn);

        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
    }
}
