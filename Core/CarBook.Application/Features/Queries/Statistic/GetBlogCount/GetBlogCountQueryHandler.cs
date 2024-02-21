using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetBlogCount
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQueryRequest, GetBlogCountQueryResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetBlogCountQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }

        public async Task<GetBlogCountQueryResponse> Handle(GetBlogCountQueryRequest request, CancellationToken cancellationToken)
        {
            var blogCount = _blogReadRepository.GetAll(false).Count();
            return new()
            {
                BlogCount = blogCount,
            };
        }
    }
}
