using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace store
{
   public class Order
    {
        public int Id { get; }

        private List<OrderItem> items;

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }

        public int State { get; }

        public int TotalCount => items.Sum(items => items.Count); 
        
        public OrderItem Get(int bookId)
        {
            int index = items.FindIndex(x => x.BookId == bookId);
            if (index == -1)
            {
                throw new InvalidOperationException("Book not found ");
            }
            else
                return items[index];
        }
        public decimal TotalPrice => items.Sum(item => item.Price * item.Count); 
        

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if(items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            Id = id;
            this.items = new List<OrderItem>(items);
        }

        public void AddOrUpdate(Book book, int count)
        {
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            int index = items.FindIndex(x => x.BookId == book.Id);
            if(index == -1)
            {
                items.Add(new OrderItem(book.Id, count, book.Price));
            }
            else
            {
                items[index].Count += count;
            }
        }

        public void AddItem(Book book, int count)
        {
            if(book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            var item = items.SingleOrDefault(x => x.BookId == book.Id);

            if(item == null)
            {
                items.Add(new OrderItem(book.Id,count,book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count + count, item.Price + count * book.Price));
            }
        }

        public void RemoveItem(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            int index = items.FindIndex(x => x.BookId == book.Id);
            if(index == -1)
            {
                throw new InvalidOperationException($"Order does not contain with curent ID");
            }
            items.RemoveAt(index);
        }
    }
}
