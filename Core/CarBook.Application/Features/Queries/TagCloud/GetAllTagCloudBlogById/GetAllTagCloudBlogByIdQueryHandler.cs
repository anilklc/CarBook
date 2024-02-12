using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.TagCloud.GetAllTagCloudBlogById
{
    public class GetAllTagCloudBlogByIdQueryHandler : IRequestHandler<GetAllTagCloudBlogByIdQueryRequest, GetAllTagCloudBlogByIdQueryResponse>
    {
        private readonly ITagCloudReadRepository _tagCloudReadRepository;

        public GetAllTagCloudBlogByIdQueryHandler(ITagCloudReadRepository tagCloudReadRepository)
        {
            _tagCloudReadRepository = tagCloudReadRepository;
        }

        public async Task<GetAllTagCloudBlogByIdQueryResponse> Handle(GetAllTagCloudBlogByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var tagClouds = _tagCloudReadRepository.GetAll(false).Where(t=>t.BlogID == Guid.Parse(request.Id)).ToList();
            return new()
            {
               TagClouds = tagClouds,
            };
        }
    }
}
