using MediatR;

namespace CarBook.Application.Features.Commands.TagCloud.UpdateTagCloud
{
    public class UpdateTagCloudCommandRequest : IRequest<UpdateTagCloudCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Guid BlogID { get; set; }
    }
}