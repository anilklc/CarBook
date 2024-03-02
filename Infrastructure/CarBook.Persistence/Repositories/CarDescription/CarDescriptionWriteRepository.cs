using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class CarDescriptionWriteRepository : WriteRepository<CarDescription>, ICarDescriptionWriteRepository
    {
        public CarDescriptionWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
