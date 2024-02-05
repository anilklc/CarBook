using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class FooterAddressWriteRepository : WriteRepository<FooterAddress>, IFooterAddressWriteRepository
    {
        public FooterAddressWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
