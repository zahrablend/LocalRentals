using System.ComponentModel.DataAnnotations;

namespace LocalRentalsApi.Models.Dto
{
    // DTOs provide a wrapper between the entity or database model
    // and what is being exposed from API.
    public class RentalDto
    {
        // Properties match Model properties
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(6)]
        public string? Name { get; set; }
        public int MaxPeople { get; set; }
        public int Area { get; set; }
    }
}
