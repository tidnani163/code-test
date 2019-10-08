using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.Services
{
    public interface IAddressBookService
    {
        Task<int> GetCountbyGender(string gender);

        Task<Person> GetOldestPerson();

        Task<int?> GetAgeDifference(string person1Name, string person2Name);
    }
}
