using MediatR;

namespace CarBook.Application.Features.Queries.Car.GetByIdCar
{
    public class GetByIdCarQueryRequest : IRequest<GetByIdCarQueryResponse>
    {
        public Guid Id { get; set; }
    }
}