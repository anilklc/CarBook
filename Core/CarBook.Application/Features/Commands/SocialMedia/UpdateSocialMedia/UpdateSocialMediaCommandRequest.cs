using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.SocialMedia.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandRequest : IRequest<UpdateSocialMediaCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

    }
}