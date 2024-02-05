﻿using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.SocialMedia.CreateSocialMedia
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommandRequest, CreateSocialMediaCommandResponse>
    {
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;

        public CreateSocialMediaCommandHandler(ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaWriteRepository = socialMediaWriteRepository;
        }

        public async Task<CreateSocialMediaCommandResponse> Handle(CreateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            await _socialMediaWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Icon = request.Icon,
                Url = request.Url,
            });
            await _socialMediaWriteRepository.SaveAsync();
            return new();
        }
    }
}
