using System;
using AddressBook.Controllers;
using AddressBook.Models;
using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AddressBook.Tests
{
    public class AddressControllerTests
    {
        private Mock<IAddressBookService> _addressBookService;
        private AddressBookController classUnderTest;

        private void InitializeTestData()
        {
            _addressBookService = new Mock<IAddressBookService>();
            classUnderTest = new AddressBookController(_addressBookService.Object);
        }
        
        [Fact]
        public void TestGetCountbyGenderSuccess()
        {
            InitializeTestData();
            _addressBookService.Setup(c => c.GetCountbyGender(It.IsAny<string>())).ReturnsAsync(1);
            var result = classUnderTest.GetCountbyGender("Male");
            Assert.Equal(1, ((ObjectResult)(result.Result)).Value);
        }

        [Fact]
        public void TestGetCountbyGenderException()
        {
            InitializeTestData();
            _addressBookService.Setup(c => c.GetCountbyGender(It.IsAny<string>())).ThrowsAsync(new Exception());
            var result = classUnderTest.GetCountbyGender("Male");
            Assert.Equal(500, ((StatusCodeResult)(result.Result)).StatusCode);
        }

        [Fact]
        public void TestGetOldestPersonSuccess()
        {
            InitializeTestData();
            var person = new Person { Name = "test", Gender = "Male", DateOfBirth = Convert.ToDateTime("01/01/2000") };
            _addressBookService.Setup(c => c.GetOldestPerson()).ReturnsAsync(person); ;
            var result = classUnderTest.GetOldestPerson();
            Assert.Equal(person, ((ObjectResult)(result.Result)).Value);
        }

        [Fact]
        public void TestGetOldestPersonException()
        {
            InitializeTestData();
            _addressBookService.Setup(c => c.GetOldestPerson()).ThrowsAsync(new Exception());
            var result = classUnderTest.GetOldestPerson();
            Assert.Equal(500, ((StatusCodeResult)(result.Result)).StatusCode);
        }

        [Fact]
        public void TestGetAgeDifferenceSuccess()
        {
            InitializeTestData();
            _addressBookService.Setup(c => c.GetAgeDifference(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(1);
            var result = classUnderTest.GetAgeDifference("Paul", "Mac");
            Assert.Equal(1, ((ObjectResult)(result.Result)).Value);
        }

        [Fact]
        public void TestGetAgeDifferenceException()
        {
            InitializeTestData();
            _addressBookService.Setup(c => c.GetAgeDifference(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new Exception());
            var result = classUnderTest.GetAgeDifference("Paul", "Mac");
            Assert.Equal(500, ((StatusCodeResult)(result.Result)).StatusCode);
        }
    }
}
