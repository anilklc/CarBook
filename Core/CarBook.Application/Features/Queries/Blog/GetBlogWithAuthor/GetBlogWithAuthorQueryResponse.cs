using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.Blog.GetBlogWithAuthor
{
    public class GetBlogWithAuthorQueryResponse
    {
        public List<BlogAndAuthorDto> BlogAndAuthor { get; set; }
    }
}