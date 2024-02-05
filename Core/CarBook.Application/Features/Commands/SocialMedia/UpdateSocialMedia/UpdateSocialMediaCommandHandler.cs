using CarBook.Application.Features.Commands.SocialMedia.UpdateSocialMedia;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.SocialMedia.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommandRequest, UpdateSocialMediaCommandResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;

        public UpdateSocialMediaCommandHandler(ISocialMediaReadRepository socialMediaReadRepository, ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
            _socialMediaWriteRepository = socialMediaWriteRepository;
        }

        public async Task<UpdateSocialMediaCommandResponse> Handle(UpdateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            var socialMedia = await _socialMediaReadRepository.GetByIdAsync(request.Id);
            socialMedia.Url = request.Url;
            socialMedia.Name = request.Name;
            socialMedia.Icon = request.Icon;
            await _socialMediaWriteRepository.SaveAsync();
            return new();

        }
    }
}
