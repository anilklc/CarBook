using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.About.GetByIdAbout
{
    public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQueryRequest, GetByIdAboutQueryResponse>
    {
        private readonly IAboutReadRepository _aboutReadRepository;

        public GetByIdAboutQueryHandler(IAboutReadRepository aboutReadRepository)
        {
            _aboutReadRepository = aboutReadRepository;
        }

        public async Task<GetByIdAboutQueryResponse> Handle(GetByIdAboutQueryRequest request, CancellationToken cancellationToken)
        {
            var abouts = await _aboutReadRepository.GetByIdAsync(request.Id,false);
            return new()
            {
                Description = abouts.Description,
                ImageUrl = abouts.ImageUrl,
                Title = abouts.Title,
            };
        }
    }
}
