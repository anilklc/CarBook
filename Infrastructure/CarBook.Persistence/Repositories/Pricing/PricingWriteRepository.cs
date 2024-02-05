using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class PricingWriteRepository : WriteRepository<Pricing>, IPricingWriteRepository
    {
        public PricingWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
