using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class FeatureWriteRepository : WriteRepository<Feature>, IFeatureWriteRepository
    {
        public FeatureWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
