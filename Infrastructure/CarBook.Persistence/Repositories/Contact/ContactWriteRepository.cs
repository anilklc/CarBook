using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class ContactWriteRepository : WriteRepository<Domain.Entities.Contact>, IContactWriteRepository
    {
        public ContactWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
