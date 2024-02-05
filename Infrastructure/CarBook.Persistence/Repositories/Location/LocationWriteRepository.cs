using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class LocationWriteRepository : WriteRepository<Location>, ILocationWriteRepository
    {
        public LocationWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
