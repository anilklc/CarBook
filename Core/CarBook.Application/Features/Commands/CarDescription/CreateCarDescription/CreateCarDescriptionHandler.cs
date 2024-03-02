using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CarDescription.CreateCarDescription
{
    public class CreateCarDescriptionHandler : IRequestHandler<CreateCarDescriptionRequest, CreateCarDescriptionResponse>
    {
        private readonly ICarDescriptionWriteRepository _carDescriptionWriteRepository;

        public CreateCarDescriptionHandler(ICarDescriptionWriteRepository carDescriptionWriteRepository)
        {
            _carDescriptionWriteRepository = carDescriptionWriteRepository;
        }

        public async Task<CreateCarDescriptionResponse> Handle(CreateCarDescriptionRequest request, CancellationToken cancellationToken)
        {
            await _carDescriptionWriteRepository.AddAsync(new()
            {
                CarID =request.CarId,
                Description = request.Description,
            });
            await _carDescriptionWriteRepository.SaveAsync();
            return new();
        }
    }
}
