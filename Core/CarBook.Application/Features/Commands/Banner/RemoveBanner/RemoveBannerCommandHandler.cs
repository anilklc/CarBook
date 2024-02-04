using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Banner.RemoveBanner
{
    public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommandRequest, RemoveBannerCommandResponse>
    {
        private readonly IBannerWriteRepository _bannerWriteRepository;

        public RemoveBannerCommandHandler(IBannerWriteRepository bannerWriteRepository)
        {
            _bannerWriteRepository = bannerWriteRepository;
        }

        public async Task<RemoveBannerCommandResponse> Handle(RemoveBannerCommandRequest request, CancellationToken cancellationToken)
        {
            await _bannerWriteRepository.RemoveAsync(request.Id);
            await _bannerWriteRepository.SaveAsync();
            return new();
        }
    }
}
