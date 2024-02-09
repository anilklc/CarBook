using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, CreateAuthorCommandResponse>
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;

        public CreateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository)
        {
            _authorWriteRepository = authorWriteRepository;
        }

        public async Task<CreateAuthorCommandResponse> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            await _authorWriteRepository.AddAsync(new()
            {
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
            });
            await _authorWriteRepository.SaveAsync();
            return new();
        }
    }
}
