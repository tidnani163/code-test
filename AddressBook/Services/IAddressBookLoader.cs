using System.Collections.Generic;
using AddressBook.Models;

namespace AddressBook.Services
{
    public interface IAddressBookLoader
    {
        IList<Person> LoadAddressBook();
    }
}
