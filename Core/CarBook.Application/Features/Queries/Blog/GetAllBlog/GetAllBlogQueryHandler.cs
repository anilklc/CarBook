using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Blog.GetAllBlog
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest, GetAllBlogQueryResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetAllBlogQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }

        public async Task<GetAllBlogQueryResponse> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = _blogReadRepository.GetAll(false).ToList();
            return new()
            {
                Blogs = blogs,
            };
        }
    }
}
