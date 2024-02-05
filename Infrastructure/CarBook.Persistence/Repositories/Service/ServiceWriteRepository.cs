using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class ServiceWriteRepository : WriteRepository<Service>, IServiceWriteRepository
    {
        public ServiceWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
