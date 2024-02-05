using MediatR;

namespace CarBook.Application.Features.Queries.Service.GetByIdService
{
    public class GetByIdServiceQueryRequest : IRequest<GetByIdServiceQueryResponse>
    {
        public string Id { get; set; }
    }
}