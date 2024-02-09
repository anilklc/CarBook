using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Brand.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IBrandWriteRepository _brandWriteRepository;

        public UpdateBrandCommandHandler(IBrandReadRepository brandReadRepository, IBrandWriteRepository brandWriteRepository)
        {
            _brandReadRepository = brandReadRepository;
            _brandWriteRepository = brandWriteRepository;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandReadRepository.GetByIdAsync(request.Id);
            brand.Name = request.Name;
            await _brandWriteRepository.SaveAsync();
            return new();

        }
    }
}
