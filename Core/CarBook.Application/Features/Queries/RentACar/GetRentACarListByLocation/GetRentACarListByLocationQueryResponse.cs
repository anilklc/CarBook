using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.RentACar.GetRentACarListByLocation
{
    public class GetRentACarListByLocationQueryResponse
    {
        public List<RentACarDto> Cars { get; set; }
    }
}