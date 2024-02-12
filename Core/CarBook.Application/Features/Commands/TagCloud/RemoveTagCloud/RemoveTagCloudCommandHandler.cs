using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.TagCloud.RemoveTagCloud
{
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommandRequest, RemoveTagCloudCommandResponse>
    {
        private readonly ITagCloudWriteRepository _tagCloudWriteRepository;

        public RemoveTagCloudCommandHandler(ITagCloudWriteRepository tagCloudWriteRepository)
        {
            _tagCloudWriteRepository = tagCloudWriteRepository;
        }

        public async Task<RemoveTagCloudCommandResponse> Handle(RemoveTagCloudCommandRequest request, CancellationToken cancellationToken)
        {
            await _tagCloudWriteRepository.RemoveAsync(request.Id);
            await _tagCloudWriteRepository.SaveAsync();
            return new();
        }
    }
}
