using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class TagCloudWriteRepository : WriteRepository<TagCloud>, ITagCloudWriteRepository
    {
        public TagCloudWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
