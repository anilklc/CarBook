using MediatR;

namespace CarBook.Application.Features.Queries.CarFeature.GetWithByCarId
{
    public class GetWithByCarIdQueryRequest : IRequest<GetWithByCarIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}