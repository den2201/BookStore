using System;
using System.Collections.Generic;
using System.Text;

namespace store
{
    public class Book
    {
        public int Id { get; }

        public string Title { get; }

        public string Isbn { get; }

        public Book (int id, string title, string Isbn)
        {
            Id = id;
            Title = title;
            this.Isbn = Isbn;
        }
    }
}
