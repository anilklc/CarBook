using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class RentACarWriteRepository : WriteRepository<RentACar>, IRentACarWriteRepository
    {
        public RentACarWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
