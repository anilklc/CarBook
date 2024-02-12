using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.TagCloud.GetByIdTagCloud
{
    public class GetByIdTagCloudQueryHandler : IRequestHandler<GetByIdTagCloudQueryRequest, GetByIdTagCloudQueryResponse>
    {
        private readonly ITagCloudReadRepository _tagCloudReadRepository;

        public GetByIdTagCloudQueryHandler(ITagCloudReadRepository tagCloudReadRepository)
        {
            _tagCloudReadRepository = tagCloudReadRepository;
        }

        public async Task<GetByIdTagCloudQueryResponse> Handle(GetByIdTagCloudQueryRequest request, CancellationToken cancellationToken)
        {
            var tagCloud = await _tagCloudReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = tagCloud.Id,
                Title = tagCloud.Title,
                BlogID = tagCloud.BlogID,
            };
        }
    }
}
