using System;
using System.Collections.Generic;
using System.IO;
using AddressBook.Models;
using Microsoft.Extensions.Logging;

namespace AddressBook.Services
{
    public class CsvReader : IAddressBookLoader
    {

        private readonly ILogger<CsvReader> _logger;

        private const string _fileName = "AddressBook";//TODO: move to appsettings.json or k8 charts 
        public CsvReader(ILogger<CsvReader> logger)
        {
            _logger = logger;
        }


        public IList<Person> LoadAddressBook()
        {
            var personList = new List<Person>();
            string[] personLines = null;

            try
            {
                personLines = File.ReadAllLines(_fileName);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error Reading file");
            }

            foreach (var line in personLines)
            {
                try
                {
                    var person = line.Split(',');
                    personList.Add(new Person { Name = person[0].Trim(), Gender = person[1].Trim(), DateOfBirth = Convert.ToDateTime(person[2]) });
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error parsing Line : {line}");
                }
            }

            return personList;
        }
    }
}
