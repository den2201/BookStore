using System;
using System.Collections.Generic;
using System.Text;

namespace store
{
    public class Cart
    {
       public int OrderId { get; }

       public int TotalCount { get; set; }

        public decimal TotalPrice { get; set; }

        public Cart(int orderId)
        {
            OrderId = orderId;
            TotalCount = 0;
            TotalPrice = 0m;

        }




    }
}
