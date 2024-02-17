namespace CarBook.Application.Features.Queries.Comment.GetByIdComment
{
    public class GetByIdCommentQueryResponse
    {
        public string Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public Guid BlogID { get; set; }
    }
}