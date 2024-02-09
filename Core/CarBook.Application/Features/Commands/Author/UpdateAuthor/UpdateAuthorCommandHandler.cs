using CarBook.Application.Features.Commands.Author.RemoveAuthor;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, UpdateAuthorCommandResponse>
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IAuthorWriteRepository _authorWriteRepository;

        public UpdateAuthorCommandHandler(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }

        public async Task<UpdateAuthorCommandResponse> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorReadRepository.GetByIdAsync(request.Id);
            author.Description = request.Description;
            author.Name = request.Name;
            author.ImageUrl = request.ImageUrl;
            await _authorWriteRepository.SaveAsync();
            return new();
        }
    }
}
