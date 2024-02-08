using MediatR;

namespace CarBook.Application.Features.Commands.Blog.CreateBlog
{
    public class CreateBlogCommandRequest : IRequest<CreateBlogCommandResponse>
    {
        public string Title { get; set; }
        public Guid AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid CategoryID { get; set; }
    }
}