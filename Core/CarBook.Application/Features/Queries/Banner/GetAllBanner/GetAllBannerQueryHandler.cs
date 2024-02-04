using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Banner.GetAllBanner
{
    public class GetAllBannerQueryHandler : IRequestHandler<GetAllBannerQueryRequest, GetAllBannerQueryResponse>
    {
        private readonly IBannerReadRepository _bannerReadRepository;

        public GetAllBannerQueryHandler(IBannerReadRepository bannerReadRepository)
        {
            _bannerReadRepository = bannerReadRepository;
        }

        public async Task<GetAllBannerQueryResponse> Handle(GetAllBannerQueryRequest request, CancellationToken cancellationToken)
        {
            var banners =  _bannerReadRepository.GetAll(false).ToList();
            return new()
            {
                Banners = banners,
            };
        }
    }
}
