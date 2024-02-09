using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Blog.GetBlogWithAuthor
{
    public class GetBlogWithAuthorQueryHandler : IRequestHandler<GetBlogWithAuthorQueryRequest, GetBlogWithAuthorQueryResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetBlogWithAuthorQueryHandler(IBlogReadRepository blogReadRepository, IAuthorReadRepository authorReadRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _blogReadRepository = blogReadRepository;
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetBlogWithAuthorQueryResponse> Handle(GetBlogWithAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = _blogReadRepository.GetAll(false).OrderByDescending(b => b.Id).ToList();
            var mapper = _mapper.Map<List<BlogAndAuthorDto>>(blogs);

            foreach (var blogAndAuthorDto in mapper)
            {
                var author = _authorReadRepository.GetAll(false);
                var category =_categoryReadRepository.GetAll(false);
                blogAndAuthorDto.AuthorName = author.FirstOrDefault(b => b.Id == blogAndAuthorDto.AuthorID).Name;
                blogAndAuthorDto.CategoryName = category.FirstOrDefault(c => c.Id == blogAndAuthorDto.CategoryID).Name;
            }

            return new()
            {
                BlogAndAuthor = mapper,
            };
        }
    }
}
