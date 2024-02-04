using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryResponse
    {
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}