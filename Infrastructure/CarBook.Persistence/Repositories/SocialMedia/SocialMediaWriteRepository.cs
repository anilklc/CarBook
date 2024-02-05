using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class SocialMediaWriteRepository : WriteRepository<SocialMedia>, ISocialMediaWriteRepository
    {
        public SocialMediaWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
