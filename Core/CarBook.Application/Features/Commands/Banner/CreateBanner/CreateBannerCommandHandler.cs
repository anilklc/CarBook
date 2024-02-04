using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Banner.CreateBanner
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommandRequest, CreateBannerCommandResponse>
    {
        private readonly IBannerWriteRepository _bannerWriteRepository;
        public CreateBannerCommandHandler(IBannerWriteRepository bannerWriteRepository)
        {
            _bannerWriteRepository = bannerWriteRepository;
        }

        public async Task<CreateBannerCommandResponse> Handle(CreateBannerCommandRequest request, CancellationToken cancellationToken)
        {
            await _bannerWriteRepository.AddAsync(new()
            {
              Description = request.Description,
              Title = request.Title,
              VideoDescription  = request.VideoDescription,
              VideoUrl = request.VideoUrl,
            });
            await _bannerWriteRepository.SaveAsync();
            return new();
        }
    }
}
