using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Blog.GetLastThreeBlog
{
    public class GetLastThreeBlogQueryHandler : IRequestHandler<GetLastThreeBlogQueryRequest, GetLastThreeBlogQueryResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IMapper _mapper;
        public GetLastThreeBlogQueryHandler(IBlogReadRepository blogReadRepository, IAuthorReadRepository authorReadRepository, IMapper mapper)
        {
            _blogReadRepository = blogReadRepository;
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
        }

        public async Task<GetLastThreeBlogQueryResponse> Handle(GetLastThreeBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs =  _blogReadRepository.GetAll(false).OrderByDescending(b=> b.Id).Take(3).ToList();
            var mapper = _mapper.Map<List<BlogAndAuthorDto>>(blogs);

            foreach (var blogAndAuthorDto in mapper)
            {
                var author = _authorReadRepository.GetAll(false);
                blogAndAuthorDto.AuthorName = author.FirstOrDefault(b => b.Id == blogAndAuthorDto.AuthorID).Name;
            }

            return new()
            {
                BlogAndAuthor = mapper
            };

        }
    }
}
