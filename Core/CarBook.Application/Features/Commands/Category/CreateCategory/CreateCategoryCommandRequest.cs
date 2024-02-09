using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}