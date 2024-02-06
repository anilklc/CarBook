using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class TestimonialWriteRepository : WriteRepository<Domain.Entities.Testimonial>, ITestimonialWriteRepository
    {
        public TestimonialWriteRepository(CarBookDbContext context) : base(context)
        {
        }
    }
}
