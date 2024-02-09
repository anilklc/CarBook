using CarBook.Application.Interfaces.Repositories;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class CarPricingReadRepository : ReadRepository<Domain.Entities.CarPricing>, ICarPricingReadRepository
    {
        public CarPricingReadRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
