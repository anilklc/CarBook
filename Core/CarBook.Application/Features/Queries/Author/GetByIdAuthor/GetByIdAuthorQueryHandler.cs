using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Author.GetByIdAuthor
{
    public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQueryRequest, GetByIdAuthorQueryResponse>
    {
        private readonly IAuthorReadRepository _authorReadRepository;

        public GetByIdAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }

        public async Task<GetByIdAuthorQueryResponse> Handle(GetByIdAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Blogs = author.Blogs,
                Description = author.Description,
                ImageUrl = author.ImageUrl,
                Name = author.Name,
            };
        }
    }
}
