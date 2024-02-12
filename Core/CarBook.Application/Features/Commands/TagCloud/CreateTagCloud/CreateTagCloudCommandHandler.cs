using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.TagCloud.CreateTagCloud
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommandRequest, CreateTagCloudCommandResponse>
    {
        private readonly ITagCloudWriteRepository _tagCloudWriteRepository;

        public CreateTagCloudCommandHandler(ITagCloudWriteRepository tagCloudWriteRepository)
        {
            _tagCloudWriteRepository = tagCloudWriteRepository;
        }

        public async Task<CreateTagCloudCommandResponse> Handle(CreateTagCloudCommandRequest request, CancellationToken cancellationToken)
        {
            await _tagCloudWriteRepository.AddAsync(new()
            {
                Title = request.Title,
                BlogID = request.BlogID,
            });
            await _tagCloudWriteRepository.SaveAsync();
            return new();

        }
    }
}
