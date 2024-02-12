using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.TagCloud.GetAllTagCloud
{
    public class GetAllTagCloudQueryHandler : IRequestHandler<GetAllTagCloudQueryRequest, GetAllTagCloudQueryResponse>
    {
        private readonly ITagCloudReadRepository _tagCloudReadRepository;

        public GetAllTagCloudQueryHandler(ITagCloudReadRepository tagCloudReadRepository)
        {
            _tagCloudReadRepository = tagCloudReadRepository;
        }

        public async Task<GetAllTagCloudQueryResponse> Handle(GetAllTagCloudQueryRequest request, CancellationToken cancellationToken)
        {
            var tagClouds = _tagCloudReadRepository.GetAll(false).ToList();
            return new() 
            {
                TagClouds = tagClouds,
            };
        }
    }
}
