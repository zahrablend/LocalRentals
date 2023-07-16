using LocalRentalsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalRentalsApi.Controllers
{
    // Add route to API mapped => app.MapControllers() in Program.cs
    [Route("api/RentalsApi")]
    // Create an endpoint
    [ApiController]
    public class RentalsApiController : ControllerBase
    {
        // Specify GET endpoint for return statement
        [HttpGet]
        public IEnumerable<Rental> GetRentals()
        {
            return new List<Rental>
            {
                new Rental{Id=1, Name="LR-01"},
                new Rental{Id=2,Name="LR-02"}
            };
        }
    }
}
