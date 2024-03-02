using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.CarDescription
{
    public class GetCarDescriptionWithByCarIdHandler : IRequestHandler<GetCarDescriptionWithByCarIdRequest, GetCarDescriptionWithByCarIdResponse>
    {
        private readonly ICarDescriptionReadRepository _carDescriptionReadRepository;

        public GetCarDescriptionWithByCarIdHandler(ICarDescriptionReadRepository carDescriptionReadRepository)
        {
            _carDescriptionReadRepository = carDescriptionReadRepository;
        }

        public async Task<GetCarDescriptionWithByCarIdResponse> Handle(GetCarDescriptionWithByCarIdRequest request, CancellationToken cancellationToken)
        {
            var carDescription = await _carDescriptionReadRepository.GetSingleAsync(cd=>cd.CarID==request.Id);
            return new()
            {
                CarDescription = carDescription,
            };
        }
    }
}
