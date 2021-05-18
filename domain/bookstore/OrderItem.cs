using System;
using System.Collections.Generic;
using System.Text;

namespace store
{
   public  class OrderItem
    {
        private int count;
        public int BookId { get; }

        public int Count { get { return count; }
            set {
                ThrowIfInvalidCount(value);
                count = value;
            }
        }

        public decimal Price { get; }

        public OrderItem(int bookId, int count, decimal price)
        {
            ThrowIfInvalidCount(count);
            BookId = bookId;
            Count = count;
            Price = price;
        }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count is less or equal zero");
            }
        }
    }
}
