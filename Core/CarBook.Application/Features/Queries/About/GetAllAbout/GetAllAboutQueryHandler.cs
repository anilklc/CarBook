﻿using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.About.GetAllAbout
{
    public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQueryRequest, GetAllAboutQueryResponse>
    {
        private readonly IAboutReadRepository _aboutReadRepository;

        public GetAllAboutQueryHandler(IAboutReadRepository aboutReadRepository)
        {
            _aboutReadRepository = aboutReadRepository;
        }

        public async Task<GetAllAboutQueryResponse> Handle(GetAllAboutQueryRequest request, CancellationToken cancellationToken)
        {
            var abouts = _aboutReadRepository.GetAll(false).ToList();
            return new()
            {
                Abouts = abouts,
            };
        }
    }
}
