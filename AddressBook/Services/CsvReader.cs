using System;
using System.Collections.Generic;
using System.IO;
using AddressBook.Models;
using Microsoft.Extensions.Logging;

namespace AddressBook.Services
{
    public class CsvReader : IAddressBookLoader
    {
        public IList<Person> LoadAddressBook()
        {
            var personList = new List<Person>();

            Person person1 = new Person { Name = "John Snow", Gender = "Male", DateOfBirth = Convert.ToDateTime("16/03/77") };
            Person person2 = new Person { Name = "Jimmy Neutron", Gender = "Male", DateOfBirth = Convert.ToDateTime("17/03/77") };
            Person person3 = new Person { Name = "Dana Lane", Gender = "Female", DateOfBirth = Convert.ToDateTime("20/11/91") };
            personList.Add(person1);
            personList.Add(person2);
            personList.Add(person3);

            return personList;
        }
    }
}
