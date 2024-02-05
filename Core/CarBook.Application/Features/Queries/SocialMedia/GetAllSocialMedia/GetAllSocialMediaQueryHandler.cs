using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.SocialMedia.GetAllSocialMedia
{
    public class GetAllSocialMediaQueryHandler : IRequestHandler<GetAllSocialMediaQueryRequest, GetAllSocialMediaQueryResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;

        public GetAllSocialMediaQueryHandler(ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
        }

        public async Task<GetAllSocialMediaQueryResponse> Handle(GetAllSocialMediaQueryRequest request, CancellationToken cancellationToken)
        {
            var socialMedias = _socialMediaReadRepository.GetAll(false).ToList();
            return new()
            {
                SocialMedias = socialMedias,
            };
        }
    }
}
