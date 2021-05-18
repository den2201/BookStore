using System.Collections.Generic;
using store;


namespace Store.Tests
{
    public class StrubBookRepository : IBookRepository
    {
       Book[] ResultOfGetAllByIsbn { get; set; }

        Book[] ResultGetAllByTitleOrAuthor { get; set; }

        Book [] ResultGetAllbookByListId { get; set; }

        Book ResultGetById { get; set; }

        public Book[] GetAllBooksById(IEnumerable<int> idList)
        {
            return ResultGetAllbookByListId;
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return ResultOfGetAllByIsbn;
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return ResultGetAllByTitleOrAuthor;
        }

        public Book GetById(int id)
        {
            return ResultGetById;
        }
    }
}
