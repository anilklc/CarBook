using CarBook.Application.Features.Queries.Category.GetAllCategory;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Comment.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQueryRequest, GetAllCommentQueryResponse>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetAllCommentQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<GetAllCommentQueryResponse> Handle(GetAllCommentQueryRequest request, CancellationToken cancellationToken)
        {
            var comments = _commentReadRepository.GetAll(false).ToList();
            return new()
            {
                Comments = comments
            };
        }
    }
}
