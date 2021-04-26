﻿using store;


namespace Store.Tests
{
    public class StrubBookRepository : IBookRepository
    {
       Book[] ResultOfGetAllByIsbn { get; set; }

        Book[] ResultGetAllByTitleOrAuthor { get; set; }

        Book ResultGetById { get; set; }

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
