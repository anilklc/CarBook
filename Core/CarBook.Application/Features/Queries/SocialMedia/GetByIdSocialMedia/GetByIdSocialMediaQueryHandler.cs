using CarBook.Application.Features.Queries.SocialMedia.GetByIdSocialMedia;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.SocialMedia.GetByIdSocialMedia
{
    public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQueryRequest, GetByIdSocialMediaQueryResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        public GetByIdSocialMediaQueryHandler(ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
        }
        public async Task<GetByIdSocialMediaQueryResponse> Handle(GetByIdSocialMediaQueryRequest request, CancellationToken cancellationToken)
        {
            var socialMeadia = await _socialMediaReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Icon = socialMeadia.Icon,
                Name = socialMeadia.Name,
                Url = socialMeadia.Url,
            };
         
        }
    }
}

