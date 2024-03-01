using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Comment.GetCommentByIdBlog
{
    public class GetCommentByIdBlogQueryHandler : IRequestHandler<GetCommentByIdBlogQueryRequest, GetCommentByIdBlogQueryResponse>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetCommentByIdBlogQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<GetCommentByIdBlogQueryResponse> Handle(GetCommentByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var comments = _commentReadRepository.GetAll(false).Where(c =>c.BlogID == request.blogId).ToList();
            return new()
            {
                Comments = comments,

            };
        }
    }
}
