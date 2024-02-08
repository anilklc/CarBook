namespace CarBook.Application.Features.Queries.Blog.GetByIdBlog
{
    public class GetByIdBlogQueryResponse
    {
        public string Title { get; set; }
        public Guid AuthorID { get; set; }
        public Domain.Entities.Author Author { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid CategoryID { get; set; }
        public Domain.Entities.Category Category { get; set; }
    }
}