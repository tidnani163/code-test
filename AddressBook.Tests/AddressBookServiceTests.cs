using System;
using System.Collections.Generic;
using AddressBook.Models;
using AddressBook.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AddressBook.Tests
{
    public class AddressBookServiceTests
    {
        private Mock<IAddressBookLoader> _addressBookLoader;
        private Mock<ILogger<AddressBookService>> _logger;
        private AddressBookService classUnderTest;

        public AddressBookServiceTests()
        {
            _addressBookLoader = new Mock<IAddressBookLoader>();
            _logger = new Mock<ILogger<AddressBookService>>();
            
        }

        [Fact]
        public void TestGetCountbyGenderSuccess()
        {
            var personList = new List<Person>{ new Person { Name = "George", Gender = "Male" } };
            _addressBookLoader.Setup(c => c.LoadAddressBook()).Returns(personList);

            classUnderTest = new AddressBookService(_addressBookLoader.Object, _logger.Object);
            var result = classUnderTest.GetCountbyGender("Male");
            Assert.Equal(1, result.Result);
        }

        [Fact]
        public void TestGetOldestPersonSuccess()
        {
            var personList = new List<Person> { new Person { Name = "George", Gender = "Male" } };
            _addressBookLoader.Setup(c => c.LoadAddressBook()).Returns(personList);

            classUnderTest = new AddressBookService(_addressBookLoader.Object, _logger.Object);
            var result = classUnderTest.GetOldestPerson();
            Assert.Equal(personList[0], result.Result);
        }

        [Fact]
        public void TestGetAgeDifferenceSuccess()
        {
            var personList = new List<Person> { new Person { Name = "George", Gender = "Male", DateOfBirth = Convert.ToDateTime("01/01/2001") }, new Person {Name = "Beck", Gender="Male", DateOfBirth=Convert.ToDateTime("01/01/2000") } };
            _addressBookLoader.Setup(c => c.LoadAddressBook()).Returns(personList);

            classUnderTest = new AddressBookService(_addressBookLoader.Object, _logger.Object);
            var result = classUnderTest.GetAgeDifference("Beck","George");
            Assert.Equal(366, result.Result);
        }

        [Fact]
        public void TestGetAgeDifferenceError()
        {
            var personList = new List<Person> { new Person { Name = "George", Gender = "Male", DateOfBirth = Convert.ToDateTime("01/01/2001") }, new Person { Name = "Beck", Gender = "Male", DateOfBirth = Convert.ToDateTime("01/01/2000") } };
            _addressBookLoader.Setup(c => c.LoadAddressBook()).Returns(personList);

            classUnderTest = new AddressBookService(_addressBookLoader.Object, _logger.Object);
            var result = classUnderTest.GetAgeDifference("Beck", "Jack");
            Assert.Null(result.Result);
        }
    }
}
