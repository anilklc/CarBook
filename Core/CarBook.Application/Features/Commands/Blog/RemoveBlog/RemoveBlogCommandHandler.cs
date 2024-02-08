using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Blog.RemoveBlog
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommandRequest, RemoveBlogCommandResponse>
    {
        private readonly IBlogWriteRepository _blogWriteRepository;

        public RemoveBlogCommandHandler(IBlogWriteRepository blogWriteRepository)
        {
            _blogWriteRepository = blogWriteRepository;
        }

        public async Task<RemoveBlogCommandResponse> Handle(RemoveBlogCommandRequest request, CancellationToken cancellationToken)
        {
            await _blogWriteRepository.RemoveAsync(request.Id);
            await _blogWriteRepository.SaveAsync();
            return new();
        }
    }
}
