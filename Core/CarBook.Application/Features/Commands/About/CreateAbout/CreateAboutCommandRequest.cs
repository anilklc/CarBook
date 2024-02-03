using MediatR;

namespace CarBook.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandRequest : IRequest<CreateAboutCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}