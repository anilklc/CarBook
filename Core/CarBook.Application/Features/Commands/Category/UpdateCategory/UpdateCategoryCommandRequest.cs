using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Domain.Entities.Blog> Blogs { get; set; }
    }
}