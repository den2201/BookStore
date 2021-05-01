using store;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
   public class OrderItemTest
    {
        [Fact]
        public void OrderItem_WithZeroCount_TrhowsArgumentOutOfRangeException()
        {
            int count = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(2, count, 10m);
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_TrhowsArgumentOutOfRangeException()
        {
            int count = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(2, count, 10m);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_SetCountPropertyEqualCouunInConstructor()
        {
            int count = 4;
            var order = new OrderItem(1, count, 6m);
            Assert.Equal(count, order.Count);
        }





    }
}
