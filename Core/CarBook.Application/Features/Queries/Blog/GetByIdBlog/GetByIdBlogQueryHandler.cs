using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Blog.GetByIdBlog
{
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQueryRequest, GetByIdBlogQueryResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetByIdBlogQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }

        public async Task<GetByIdBlogQueryResponse> Handle(GetByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blog = await _blogReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Author = blog.Author,
                AuthorID = blog.AuthorID,
                Category = blog.Category,
                CategoryID = blog.CategoryID,
                CoverImageUrl = blog.CoverImageUrl,
                Title = blog.Title,
                Description = blog.Description,
                Id = blog.Id,
            };
        }
    }
}
