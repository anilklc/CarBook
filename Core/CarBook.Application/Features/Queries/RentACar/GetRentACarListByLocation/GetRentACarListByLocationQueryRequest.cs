using MediatR;

namespace CarBook.Application.Features.Queries.RentACar.GetRentACarListByLocation
{
    public class GetRentACarListByLocationQueryRequest : IRequest<GetRentACarListByLocationQueryResponse>
    {
        public Guid Id { get; set; }
        public bool available { get; set; }
    }
}