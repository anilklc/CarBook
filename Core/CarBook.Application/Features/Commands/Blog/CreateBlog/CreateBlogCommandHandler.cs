using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Blog.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommandRequest, CreateBlogCommandResponse>
    {
        private readonly IBlogWriteRepository _blogWriteRepository;

        public CreateBlogCommandHandler(IBlogWriteRepository blogWriteRepository)
        {
            _blogWriteRepository = blogWriteRepository;
        }

        public async Task<CreateBlogCommandResponse> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            await _blogWriteRepository.AddAsync(new()
            {     
                AuthorID = request.AuthorID,
                CoverImageUrl = request.CoverImageUrl,
                CategoryID = request.CategoryID,
                Title = request.Title,  
            });
            await _blogWriteRepository.SaveAsync();
            return new();
        }
    }
}
