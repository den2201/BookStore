using System;
using System.Collections.Generic;
using System.Text;

namespace store
{
    public interface IBookRepositoty
    {
        Book[] GetAllByTitle(string title);

    }
}
