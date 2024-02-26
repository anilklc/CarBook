using MediatR;

namespace CarBook.Application.Features.Commands.Reservation.CreateReservation
{
    public class CreateReservationCommandRequest : IRequest<CreateReservationCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid? PickUpLocationID { get; set; }
        public Guid? DropOffLocationID { get; set; }
        public Guid CarID { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
        
    }
}