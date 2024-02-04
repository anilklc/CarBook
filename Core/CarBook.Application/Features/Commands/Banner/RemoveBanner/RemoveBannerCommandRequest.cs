using MediatR;

namespace CarBook.Application.Features.Commands.Banner.RemoveBanner
{
    public class RemoveBannerCommandRequest : IRequest<RemoveBannerCommandResponse>
    {
        public string Id { get; set; }
    }
}