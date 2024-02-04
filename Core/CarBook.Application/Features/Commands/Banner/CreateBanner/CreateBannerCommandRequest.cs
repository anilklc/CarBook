using MediatR;

namespace CarBook.Application.Features.Commands.Banner.CreateBanner
{
    public class CreateBannerCommandRequest : IRequest<CreateBannerCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}