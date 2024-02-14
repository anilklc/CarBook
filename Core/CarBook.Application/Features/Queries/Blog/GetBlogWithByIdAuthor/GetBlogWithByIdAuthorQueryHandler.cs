using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Blog.GetBlogWithByIdAuthor
{
    public class GetBlogWithByIdAuthorQueryHandler : IRequestHandler<GetBlogWithByIdAuthorQueryRequest, GetBlogWithByIdAuthorQueryResponse>
    {
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetBlogWithByIdAuthorQueryHandler(IBlogReadRepository blogReadRepository, IAuthorReadRepository authorReadRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _blogReadRepository = blogReadRepository;
            _authorReadRepository = authorReadRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetBlogWithByIdAuthorQueryResponse> Handle(GetBlogWithByIdAuthorQueryRequest request, CancellationToken cancellationToken)
        {

            var blogs = _blogReadRepository.GetAll(false).Where(a=>a.AuthorID==Guid.Parse(request.AuthorId)).OrderByDescending(b => b.Id).ToList();
            var mapper = _mapper.Map<List<BlogAndAuthorDto>>(blogs);

            foreach (var blogAndAuthorDto in mapper)
            {
                var author = _authorReadRepository.GetAll(false);
                var category =_categoryReadRepository.GetAll(false);
                blogAndAuthorDto.AuthorName = author.FirstOrDefault(b => b.Id == blogAndAuthorDto.AuthorID).Name;
                blogAndAuthorDto.CategoryName = category.FirstOrDefault(c => c.Id == blogAndAuthorDto.CategoryID).Name;
                blogAndAuthorDto.AuthorImageUrl = author.FirstOrDefault(b => b.Id == blogAndAuthorDto.AuthorID).ImageUrl;
                blogAndAuthorDto.AuthorDescription = author.FirstOrDefault(b => b.Id == blogAndAuthorDto.AuthorID).Description;
            }
            
            return new()
            {
                BlogAndAuthor = mapper,
            };
        }
    }
}
