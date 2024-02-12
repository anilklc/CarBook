using MediatR;

namespace CarBook.Application.Features.Queries.TagCloud.GetAllTagCloudBlogById
{
    public class GetAllTagCloudBlogByIdQueryRequest : IRequest<GetAllTagCloudBlogByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}