namespace CarBook.Dto.Blog
{
    public class ResultBlogWithAuthorDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
