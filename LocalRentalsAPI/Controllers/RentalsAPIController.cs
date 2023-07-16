using LocalRentalsApi.Data;
using LocalRentalsApi.Models;
using LocalRentalsApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<RentalDto> GetRentals()
        {
            // Returns all rentals on the list
            return RentalData.rentalsList;
        }

        [HttpGet("id:int")]
        // [HttpGet("id")] => without type specified
        public RentalDto GetRentals(int id)
        {
            // returning first record only
            return RentalData.rentalsList.FirstOrDefault(v => v.Id == id);
        }
    }
}
