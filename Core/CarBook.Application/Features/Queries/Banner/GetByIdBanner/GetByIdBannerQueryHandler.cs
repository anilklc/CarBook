using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryHandler : IRequestHandler<GetByIdBannerQueryRequest, GetByIdBannerQueryResponse>
    {
        private readonly IBannerReadRepository _bannerReadRepository;

        public GetByIdBannerQueryHandler(IBannerReadRepository bannerReadRepository)
        {
            _bannerReadRepository = bannerReadRepository;
        }

        public async Task<GetByIdBannerQueryResponse> Handle(GetByIdBannerQueryRequest request, CancellationToken cancellationToken)
        {
            var banner = await _bannerReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                Description = banner.Description,
                Title = banner.Title,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl,
            };

        }
    }
}
