using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace store
{
    public class Book
    {
        public int Id { get; }

        public string Title { get; }

        public string Isbn { get; }

        public string Author { get; }

        public Book (int id, string Isbn, string author, string title)
        {
            Id = id;
            Title = title;
            this.Isbn = Isbn;
            Author = author;
        }

        internal static bool IsIsbn(string query)
        {
            if (query == null)
                return false;

            query = query.Replace("-", "").Replace(" ", "").ToUpper();

            if (Regex.IsMatch(query, @"ISBN\d{10}(\d{3})?"))
                return true;
            else
                return false;
            
        }
    }
}
