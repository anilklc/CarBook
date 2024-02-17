using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly ICommentWriteRepository _commentWriteRepository;

        public UpdateCommentCommandHandler(ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository)
        {
            _commentReadRepository = commentReadRepository;
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentReadRepository.GetByIdAsync(request.Id);
            comment.Name = request.Name;
            comment.Description = request.Description;
            comment.BlogID = request.BlogID;
            comment.Email = request.Email;
            await _commentWriteRepository.SaveAsync();
            return new();
        }
    }
}
