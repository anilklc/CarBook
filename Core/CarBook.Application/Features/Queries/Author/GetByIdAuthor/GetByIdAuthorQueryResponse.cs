using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Author.GetByIdAuthor
{
    public class GetByIdAuthorQueryResponse
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Domain.Entities.Blog> Blogs { get; set; }
    }
}