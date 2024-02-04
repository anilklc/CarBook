using CarBook.Application.Features.Commands.Banner.RemoveBanner;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Banner.UpdateBanner
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommandRequest, UpdateBannerCommandResponse>
    {
        private readonly IBannerReadRepository _bannerReadRepository;
        private readonly IBannerWriteRepository _bannerWriteRepository;
        public UpdateBannerCommandHandler(IBannerReadRepository bannerReadRepository, IBannerWriteRepository bannerWriteRepository)
        {
            _bannerReadRepository = bannerReadRepository;
            _bannerWriteRepository = bannerWriteRepository;
        }

        public async Task<UpdateBannerCommandResponse> Handle(UpdateBannerCommandRequest request, CancellationToken cancellationToken)
        {
            var banner = await _bannerReadRepository.GetByIdAsync(request.Id);
            banner.Description = request.Description;
            banner.Title = request.Title;
            banner.VideoUrl = request.VideoUrl;
            banner.VideoDescription = request.VideoDescription;
            await _bannerWriteRepository.SaveAsync();
            return new();
        }
    }
}
