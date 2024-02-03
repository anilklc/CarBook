using MediatR;

namespace CarBook.Application.Features.Commands.About.RemoveAbout
{
    public class RemoveAboutCommandRequest : IRequest<RemoveAboutCommandResponse>
    {
        public string Id { get; set; }
    }
}