using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Comment.GetByIdComment
{
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQueryRequest, GetByIdCommentQueryResponse>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetByIdCommentQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<GetByIdCommentQueryResponse> Handle(GetByIdCommentQueryRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                BlogID = comment.BlogID,
                Description = comment.Description,
                Email = comment.Email,
                Id = request.Id,
                Name = comment.Name,
            };
        }
    }
}
