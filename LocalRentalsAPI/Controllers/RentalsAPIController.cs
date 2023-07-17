using LocalRentalsApi.Data;
using LocalRentalsApi.Models;
using LocalRentalsApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LocalRentalsApi
    .Controllers
{
    // Add route to API mapped => app.MapControllers() in Program.cs
    [Route("api/RentalsApi")]
    // Alternatively no name indiceted refering to THIS controller
    // [Route("api/[controller]")]

    // Create an endpoint
    [ApiController]
    public class RentalsApiController : ControllerBase
    {
        // Specify GET endpoint for return statement
        [HttpGet]
        // Action result => implementation of Interface IAction instead of defining return type
        public ActionResult<IEnumerable<RentalDto>> GetRentals()
        {
            // Returns all rentals on the list
            return Ok(RentalData.rentalsList);
        }

        [HttpGet("id:int")]
        // Document responce code
        [ProducesResponseType(200)] //OK
        [ProducesResponseType(404)] // Not found
        [ProducesResponseType(400)] // Bad request
        // [HttpGet("id")] => without type specified
        public ActionResult<RentalDto?> GetRentals(int id)
        {
            /*
             FirstOrDefault is called on Enumerable whereas Find is called as a method on the source list.
             Find method is iterating over an array of items (since a list is a wrapper on an array).
             FirstOrDefault, on the Enumerable class, uses foreach to iterate the items (an iterator to the list and move next).
             */
            // returning first record only
            var rental = RentalData.rentalsList.FirstOrDefault(rental => rental.Id == id);
            if (id == 0)
            {
                return BadRequest();
            }
            
            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }
    }
}
