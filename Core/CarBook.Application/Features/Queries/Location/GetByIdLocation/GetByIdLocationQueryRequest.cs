using MediatR;

namespace CarBook.Application.Features.Queries.Location.GetByIdLocation
{
    public class GetByIdLocationQueryRequest : IRequest<GetByIdLocationQueryResponse>
    {
        public string Id { get; set; }
    }
}