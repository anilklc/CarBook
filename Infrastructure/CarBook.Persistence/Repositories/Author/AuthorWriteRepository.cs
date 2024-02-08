using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class AuthorWriteRepository : WriteRepository<Domain.Entities.Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
