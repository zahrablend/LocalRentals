﻿using LocalRentalsApi.Models;
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
            return new List<RentalDto>
            {
                new RentalDto{Id=1, Name="LR-01"},
                new RentalDto{Id=2,Name="LR-02"}
            };
        }
    }
}
