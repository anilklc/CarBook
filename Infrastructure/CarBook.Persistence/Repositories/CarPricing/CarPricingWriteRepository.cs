using CarBook.Application.Interfaces.Repositories;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class CarPricingWriteRepository : WriteRepository<Domain.Entities.CarPricing>, ICarPricingWriteRepository
    {
        public CarPricingWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
