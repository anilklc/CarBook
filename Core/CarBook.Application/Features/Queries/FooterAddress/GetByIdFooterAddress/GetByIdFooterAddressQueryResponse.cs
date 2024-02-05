using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.FooterAddress.GetByIdFooterAddress
{
    public class GetByIdFooterAddressQueryResponse
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}