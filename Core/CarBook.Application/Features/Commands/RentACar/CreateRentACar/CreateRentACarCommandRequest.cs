using MediatR;

namespace CarBook.Application.Features.Commands.RentACar.CreateRentACar
{
    public class CreateRentACarCommandRequest : IRequest<CreateRentACarCommandResponse>
    {
        public Guid LocationID { get; set; }
        public Guid CarID { get; set; }
        public bool Available { get; set; }
    }
}