using MediatR;

namespace CarBook.Application.Features.Commands.Category.RemoveCategory
{
    public class RemoveCategoryCommandRequest : IRequest<RemoveCategoryCommandResponse>
    {
        public string Id { get; set; }
    }
}