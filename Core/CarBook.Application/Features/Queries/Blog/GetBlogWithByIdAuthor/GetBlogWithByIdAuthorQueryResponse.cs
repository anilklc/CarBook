using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.Blog.GetBlogWithByIdAuthor
{
    public class GetBlogWithByIdAuthorQueryResponse
    {
        public List<BlogAndAuthorDto> BlogAndAuthor { get; set; }
    }
}