using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.Blog
{
    public class GetBlogByIdDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
    }
}
