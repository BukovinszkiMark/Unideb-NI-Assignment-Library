using System;
using Library_Common.Models;
using Library_Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library_server.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateMember_WithInvalidNameWithSpecialCharacter_ReturnsFalse()
        {
            // Arrange
            MemberController memberController = new MemberController();
            Member member = new Member { Id = 0, Address = "anyString", DateOfBirth = DateTime.Parse("2000-10-25T06:25:00"), Name = "Roberts? Hays" };

            // Act
            bool result = memberController.ValidateMember(member);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateMember_WithValidName_ReturnsTrue()
        {
            // Arrange
            MemberController memberController = new MemberController();
            Member member = new Member { Id = 0, Address = "anyString", DateOfBirth = DateTime.Parse("2000-10-25T06:25:00"), Name = "Roberts Hays" };

            // Act
            bool result = memberController.ValidateMember(member);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
