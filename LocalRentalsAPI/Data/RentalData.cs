using LocalRentalsApi.Models.Dto;

namespace LocalRentalsApi.Data
{
    // aka Store
    public static class RentalData
    {
        public static List<RentalDto> rentalsList = new List<RentalDto>
        {
            new RentalDto{Id=1, Name="LR-01"},
            new RentalDto{Id=2,Name="LR-02"}
        };

    }
}
