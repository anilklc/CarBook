using MediatR;

namespace CarBook.Application.Features.Queries.TagCloud.GetByIdTagCloud
{
    public class GetByIdTagCloudQueryRequest : IRequest<GetByIdTagCloudQueryResponse>
    {
        public string Id { get; set; }
    }
}