using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.TagCloud.UpdateTagCloud
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommandRequest, UpdateTagCloudCommandResponse>
    {
        private readonly ITagCloudReadRepository _tagCloudReadRepository;
        private readonly ITagCloudWriteRepository _tagCloudWriteRepository;

        public UpdateTagCloudCommandHandler(ITagCloudReadRepository tagCloudReadRepository, ITagCloudWriteRepository tagCloudWriteRepository)
        {
            _tagCloudReadRepository = tagCloudReadRepository;
            _tagCloudWriteRepository = tagCloudWriteRepository;
        }

        public async Task<UpdateTagCloudCommandResponse> Handle(UpdateTagCloudCommandRequest request, CancellationToken cancellationToken)
        {
            var tagCloud = await _tagCloudReadRepository.GetByIdAsync(request.Id);
            tagCloud.BlogID = request.BlogID;
            tagCloud.Title = request.Title;
            await _tagCloudWriteRepository.SaveAsync();
            return new();
        }
    }
}
