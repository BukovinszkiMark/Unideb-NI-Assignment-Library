using System;
using Library_Common.Models;
using Library_Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library_server.Tests
{
    [TestClass]
    public class BorrowControllerValidationTests
    {
        [TestMethod]
        public void ValidateBorrow_WithInvalidReturnDate_ReturnsFalse()
        {
            // Arrange
            BorrowController borrowController = new BorrowController();
            Borrow borrow = new Borrow { Id = 0, BookId = 0, BorrowDate = DateTime.Parse("2022-10-25T06:25:00"), ReturnDate = DateTime.Parse("2022-09-25T06:25:00"), MemberId = 0 };

            // Act
            bool result = borrowController.ValidateBorrow(borrow);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateBorrow_WithValidReturnDate_ReturnsTrue()
        {
            // Arrange
            BorrowController borrowController = new BorrowController();
            Borrow borrow = new Borrow { Id = 0, BookId = 0, BorrowDate = DateTime.Parse("2022-10-25T06:25:00"), ReturnDate = DateTime.Parse("2022-11-25T06:25:00"), MemberId = 0 };

            // Act
            bool result = borrowController.ValidateBorrow(borrow);

            // Assert
            Assert.AreEqual(true, result);
        }

    }
}
