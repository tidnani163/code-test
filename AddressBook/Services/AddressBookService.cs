using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.Extensions.Logging;

namespace AddressBook.Services
{
    public class AddressBookService : IAddressBookService
    {

        private readonly IList<Person> addressBookContacts;
        private readonly ILogger<AddressBookService> _logger;
        public AddressBookService(IAddressBookLoader addressBookLoader, ILogger<AddressBookService> logger)
        {
            _logger = logger;
            addressBookContacts = addressBookLoader.LoadAddressBook();
        }

        public async Task<int?> GetAgeDifference(string person1Name, string person2Name)
        {
            var person1 = addressBookContacts.Where(a => String.Equals(a.Name, person1Name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            var person2 = addressBookContacts.Where(a => String.Equals(a.Name, person2Name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (person1 == null || person2 == null)
            {
                _logger.LogError($"Invalid Person Names. Person1 : {person1Name} , Person2 : {person2Name}");
                return null;
            }

            return (person2.DateOfBirth - person1.DateOfBirth).Days;
        }

        public async Task<int> GetCountbyGender(string gender)
        {
            return addressBookContacts.Count(c => String.Equals(c.Gender, gender, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<Person> GetOldestPerson()
        {
            return addressBookContacts.Where(c => c.DateOfBirth == addressBookContacts.Select(d => d.DateOfBirth).Min()).FirstOrDefault();
        }
    }
}
