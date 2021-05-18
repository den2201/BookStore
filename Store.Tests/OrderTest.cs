using store;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderTest
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Order(4, null);
            });
        }

        [Fact]
        public void TotalCount_WithEmptyItems_EqualsZero()
        {
            Order order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_EqualsZero()
        {
            Order order = new Order(1, new OrderItem[0]);
            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithEmptyItems_CalculatesTotalCount()
        {
            Order order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),

                new OrderItem(2, 5 ,100m)

            });
            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_CalculatesTotalCount()
        {
            Order order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),

                new OrderItem(2, 5, 100m)

            });
            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }

        [Fact]
        public void AddItem_WithEmptyBookIem_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Order(1, new OrderItem[0]).AddItem(null, 1);

            });
        }

        [Fact]
        public void Get_WithExistingItem_ReturnItem()
        {
            Order order = new Order(1, new[]
           {
                new OrderItem(1, 3, 10m),

                new OrderItem(2, 5, 100m)

            });

            var orderItem = order.Get(2);
            Assert.Equal(5, orderItem.Count);
        }


        [Fact]
        public void Get_WithNotExistingItem_TrowsInvalidOperationException()
        {
            Order order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

           Assert.Throws<InvalidOperationException>(() =>
           {
               var orderItem = order.Get(5);
           });
        }
    }
}

