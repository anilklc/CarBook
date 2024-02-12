using MediatR;

namespace CarBook.Application.Features.Commands.TagCloud.RemoveTagCloud
{
    public class RemoveTagCloudCommandRequest : IRequest<RemoveTagCloudCommandResponse>
    {
        public string Id { get; set; }
    }
}