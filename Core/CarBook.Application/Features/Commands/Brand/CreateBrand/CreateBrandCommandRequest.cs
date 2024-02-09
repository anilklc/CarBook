using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Brand.CreateBrand
{
    public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
    {
        public string Name { get; set; }
    }
}