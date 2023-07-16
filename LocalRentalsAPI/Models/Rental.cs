namespace LocalRentalsApi.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        // Property will not be visible if not added to DTO
        public DateTime CreatedDate { get; set; }
    }
}
