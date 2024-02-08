using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class BlogWriteRepository : WriteRepository<Domain.Entities.Blog>, IBlogWriteRepository
    {
        public BlogWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
