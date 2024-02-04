using MediatR;

namespace CarBook.Application.Features.Commands.Brand.UpdateBrand
{
    public class UpdateBrandCommandRequest : IRequest<UpdateBrandCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Domain.Entities.Car> Cars { get; set; }
    }
}