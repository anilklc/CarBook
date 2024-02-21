using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetAuthorCount
{
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQueryRequest, GetAuthorCountQueryResponse>
    {
        private readonly IAuthorReadRepository _authorReadRepository;

        public GetAuthorCountQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }

        public async Task<GetAuthorCountQueryResponse> Handle(GetAuthorCountQueryRequest request, CancellationToken cancellationToken)
        {
            var authorCount = _authorReadRepository.GetAll(false).Count();
            return new()
            {
                AuthorCount = authorCount,
            };
        }
    }
}
