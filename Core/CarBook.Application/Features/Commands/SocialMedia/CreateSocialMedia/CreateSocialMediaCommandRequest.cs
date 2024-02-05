using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.SocialMedia.CreateSocialMedia
{
    public class CreateSocialMediaCommandRequest : IRequest<CreateSocialMediaCommandResponse>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}