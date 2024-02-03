using MediatR;

namespace CarBook.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandRequest : IRequest<UpdateAboutCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}