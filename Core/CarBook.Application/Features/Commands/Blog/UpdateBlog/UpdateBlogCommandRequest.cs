using MediatR;

namespace CarBook.Application.Features.Commands.Blog.UpdateBlog
{
    public class UpdateBlogCommandRequest : IRequest<UpdateBlogCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid CategoryID { get; set; }
    }
}