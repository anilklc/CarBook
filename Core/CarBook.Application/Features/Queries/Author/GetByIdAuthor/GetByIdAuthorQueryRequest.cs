using MediatR;

namespace CarBook.Application.Features.Queries.Author.GetByIdAuthor
{
    public class GetByIdAuthorQueryRequest : IRequest<GetByIdAuthorQueryResponse>
    {
        public string Id { get; set; }
    }
}