using CarBook.Application.Features.Commands.Blog.RemoveBlog;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Blog.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommandRequest, UpdateBlogCommandResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IBlogWriteRepository _blogWriteRepository;

        public UpdateBlogCommandHandler(IBlogReadRepository blogReadRepository, IBlogWriteRepository blogWriteRepository)
        {
            _blogReadRepository = blogReadRepository;
            _blogWriteRepository = blogWriteRepository;
        }

        public async Task<UpdateBlogCommandResponse> Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _blogReadRepository.GetByIdAsync(request.Id);
            blog.Title = request.Title;
            blog.AuthorID = request.AuthorID;
            blog.CategoryID = request.CategoryID;
            blog.CoverImageUrl = request.CoverImageUrl;
            await _blogWriteRepository.SaveAsync();
            return new();
        }
    }
}
