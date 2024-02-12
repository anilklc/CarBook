using MediatR;

namespace CarBook.Application.Features.Commands.TagCloud.CreateTagCloud
{
    public class CreateTagCloudCommandRequest : IRequest<CreateTagCloudCommandResponse>
    {
        public string Title { get; set; }
        public Guid BlogID { get; set; }
    }
}