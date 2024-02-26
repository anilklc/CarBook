using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.Reservation
{
    public class CreateReservationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid PickUpLocationID { get; set; }
        public Guid DropOffLocationID { get; set; }
        public Guid CarID { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
        //public string Status { get; set; }
    }
}
