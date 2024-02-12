namespace CarBook.Application.Features.Queries.TagCloud.GetByIdTagCloud
{
    public class GetByIdTagCloudQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid BlogID { get; set; }
    }
}