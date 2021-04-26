using Moq;
using store;
using StoreMemory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTest
    {
        [Fact]

        public void GetAllByQuery_WithIsbn_CallGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book(1, "", "", "","",0m) });
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "","",0m) });

            var bookService = new BookService(bookRepositoryStub.Object);
            var validIsbn = "ISBN 12345-67890";
            var actual = bookService.GetAllByQuery(validIsbn);
            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]

        public void GetAllByQuery_WithInvalidIsbn_CallGetAllTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book(1, "", "", "","",0m) });
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "","",0m) });

            var bookService = new BookService(bookRepositoryStub.Object);
            var notValidIsbn = "ISBN 12345-67";
            
            var actual = bookService.GetAllByQuery(notValidIsbn);
            
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }

    }
}
