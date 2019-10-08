using System;
using System.Net;
using System.Threading.Tasks;
using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : Controller
    {
        private readonly IAddressBookService _addressBookService;

        public AddressBookController(IAddressBookService addressBookService)
        {
            _addressBookService = addressBookService;
        }

        [HttpGet("count/{gender}")]
        [SwaggerResponse(200, Description = "The number of people by gender")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IActionResult> GetCountbyGender(string gender)
        {
            try
            {
                return Ok(await _addressBookService.GetCountbyGender(gender));
            }
            catch (Exception ex)
            {
               return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("oldestperson")]
        [SwaggerResponse(200, Description = "The oldest person in the list")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IActionResult> GetOldestPerson()
        {
            try
            {
                return Ok(await _addressBookService.GetOldestPerson());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("agedifferenceindays/person1/{person1Name}/person2/{person2Name}")]
        [SwaggerResponse(200, Description = "The age difference in days between the Person 1 and Person 2")]
        [SwaggerResponse(400, Description = "Please check person names.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IActionResult> GetAgeDifference([FromRoute] string person1Name, [FromRoute] string person2Name)
        {
            try
            {
                int? ageDifference = await _addressBookService.GetAgeDifference(person1Name, person2Name);

                if (ageDifference != null)
                    return Ok(ageDifference);
                else
                    return new BadRequestObjectResult("Please check person names.");

            }
            catch (Exception ex)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
