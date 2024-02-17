using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;

        public CreateCommentCommandHandler(ICommentWriteRepository commentWriteRepository)
        {
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _commentWriteRepository.AddAsync(new()
            {
                BlogID = request.BlogID,
                Description = request.Description,
                Email = request.Email,
                Name = request.Name,
            } );
            await _commentWriteRepository.SaveAsync();
            return new();
        }
    }
}
