using MediatR;

namespace CarBook.Application.Features.Commands.Brand.RemoveBrand
{
    public class RemoveBrandCommandRequest : IRequest<RemoveBrandCommandResponse>
    {
        public string Id { get; set; }
    }
}