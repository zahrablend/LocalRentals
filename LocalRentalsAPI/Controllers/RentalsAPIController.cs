using LocalRentalsApi.Data;
using LocalRentalsApi.Models;
using LocalRentalsApi.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public ActionResult<IEnumerable<RentalDto>> GetRental()
        {
            // Returns all rentals on the list
            return Ok(RentalData.rentalsList);
        }
        // [HttpGet("id")] => without type specified
        [HttpGet("id:int", Name ="GetRental")]
        // Document responce code hardcoded
        //[ProducesResponseType(200, Type=typeof(RentalDto))] //OK
        //[ProducesResponseType(404)]

        // Clean code
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //public ActionResult GetRentals(int id) => with Typeof in doc.responce
        public ActionResult<RentalDto?> GetRental(int id)
        {
            /*
             FirstOrDefault is called on Enumerable whereas Find is called as a method on the source list.
             Find method is iterating over an array of items (since a list is a wrapper on an array).
             FirstOrDefault, on the Enumerable class, uses foreach to iterate the items (an iterator to the list and move next).
             */
            // returning first record only
            var rental = RentalData.rentalsList.Find(rental => rental.Id == id);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        // FromBody is typical object when working with HttpPost
        public ActionResult<RentalDto?> CreateRental([FromBody]RentalDto rentalDto)
        {
            // Instead of ApiController explicitly check model state
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            // Check if rental name is unique
            if (RentalData.rentalsList.Find(rental => rental?.Name?.ToLower() == rentalDto?.Name?.ToLower()) != null)
            {
                // Add custom validation to model state
                ModelState.AddModelError("CustomError", "Rental name already exists!");
                return BadRequest(ModelState);
            }
            if (rentalDto == null)
            {
                return BadRequest(rentalDto);
            }

            if (rentalDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            rentalDto.Id = RentalData.rentalsList.OrderByDescending(rental => rental.Id).FirstOrDefault().Id + 1;
            RentalData.rentalsList.Add(rentalDto);
            return CreatedAtRoute("GetRentals", new {id = rentalDto.Id}, rentalDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteRental")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteRental(int id)
        {
            var rental = RentalData.rentalsList.Find(rental => rental.Id == id);
            if (id == 0)
            {
                return BadRequest();
            }

            if (rental == null)
            {
                return NotFound();
            }

            RentalData.rentalsList.Remove(rental);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateRental")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateRental(int id, [FromBody]RentalDto rentalDto)
        {
            var rental = RentalData.rentalsList.Find(rental => rental.Id == id);
            
            if (rentalDto == null || id != rentalDto.Id)
            {
                return BadRequest();
            }

            rental.Name = rentalDto.Name;
            rental.Area = rentalDto.Area;
            rental.MaxPeople = rentalDto.MaxPeople;

            return NoContent();
        }
    }
}
