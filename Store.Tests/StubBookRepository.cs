using store;


namespace Store.Tests
{
    public class StrubBookRepository : IBookRepository
    {
       Book[] ResultOfGetAllByIsbn { get; set; }

        Book[] ResultGetAllByTitleOrAuthor { get; set; }

        public Book[] GetAllByIsbn(string isbn)
        {
            return ResultOfGetAllByIsbn;
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return ResultGetAllByTitleOrAuthor;
        }
    }
}
