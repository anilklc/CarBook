using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Comment.RemoveComment
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommandRequest, RemoveCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;

        public RemoveCommentCommandHandler(ICommentWriteRepository commentWriteRepository)
        {
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<RemoveCommentCommandResponse> Handle(RemoveCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _commentWriteRepository.RemoveAsync(request.Id);
            await _commentWriteRepository.SaveAsync();
            return new();
        }
    }
}
