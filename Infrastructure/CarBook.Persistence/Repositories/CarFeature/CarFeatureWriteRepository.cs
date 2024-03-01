using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class CarFeatureWriteRepository : WriteRepository<CarFeature>, ICarFeatureWriteRepository
    {
        public CarFeatureWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
