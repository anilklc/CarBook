using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.SocialMedia.RemoveSocialMedia
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommandRequest, RemoveSocialMediaCommandResponse>
    {
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;

        public RemoveSocialMediaCommandHandler(ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaWriteRepository = socialMediaWriteRepository;
        }

        public async Task<RemoveSocialMediaCommandResponse> Handle(RemoveSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            await _socialMediaWriteRepository.RemoveAsync(request.Id);
            await _socialMediaWriteRepository.SaveAsync();
            return new();
        }
    }
}
