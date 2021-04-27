using System;
using System.Collections.Generic;
using System.Text;

namespace store
{
    public class Cart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();

        public decimal Amount { get; set; }
    }
}
