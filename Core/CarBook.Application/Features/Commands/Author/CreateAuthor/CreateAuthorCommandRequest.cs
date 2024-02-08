using MediatR;

namespace CarBook.Application.Features.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandRequest : IRequest<CreateAuthorCommandResponse>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Domain.Entities.Blog> Blogs { get; set; }
    }
}