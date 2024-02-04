using MediatR;

namespace CarBook.Application.Features.Commands.Banner.UpdateBanner
{
    public class UpdateBannerCommandRequest : IRequest<UpdateBannerCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}