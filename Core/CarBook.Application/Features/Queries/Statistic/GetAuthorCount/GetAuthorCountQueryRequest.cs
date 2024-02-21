using MediatR;

namespace CarBook.Application.Features.Queries.Statistic.GetAuthorCount
{
    public class GetAuthorCountQueryRequest : IRequest<GetAuthorCountQueryResponse>
    {
    }
}