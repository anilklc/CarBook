using CarBook.Application.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Blog.GetLastThreeBlog
{
    public class GetLastThreeBlogQueryResponse
    {
        public List<BlogAndAuthorDto> BlogAndAuthor { get; set; }
    }
}