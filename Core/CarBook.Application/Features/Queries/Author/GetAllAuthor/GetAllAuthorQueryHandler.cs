using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Author.GetAllAuthor
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, GetAllAuthorQueryResponse>
    {
        private readonly IAuthorReadRepository _authorReadRepository;

        public GetAllAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }

        public async Task<GetAllAuthorQueryResponse> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var authors = _authorReadRepository.GetAll(false).ToList();
            return new()
            {
                Authors = authors,
            };

        }
    }
}
