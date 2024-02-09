using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Brand.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;

        public CreateBrandCommandHandler(IBrandWriteRepository brandWriteRepository)
        {
            _brandWriteRepository = brandWriteRepository;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _brandWriteRepository.AddAsync(new()
            {
                Name = request.Name,
            });
            await _brandWriteRepository.SaveAsync();
            return new();
        }
    }
}
