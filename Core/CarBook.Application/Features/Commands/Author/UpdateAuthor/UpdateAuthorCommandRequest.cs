using MediatR;

namespace CarBook.Application.Features.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandRequest : IRequest<UpdateAuthorCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Domain.Entities.Blog> Blogs { get; set; }
    }
}