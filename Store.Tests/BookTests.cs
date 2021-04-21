using store;
using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);

            Assert.False(actual);

        }


        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("   ");

            Assert.False(actual);

        }

        [Fact]
        public void IsIsbn_With10Digits_ReturnsTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-234-122345");

            Assert.True(actual);

        }

        [Fact]
        public void IsIsbn_With13Digits_ReturnsTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-234-122345-123");

            Assert.True(actual);

        }

        [Fact]
        public void IsIsbn_With8Digits_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123-234-12");

            Assert.False(actual);

        }
    }
}
