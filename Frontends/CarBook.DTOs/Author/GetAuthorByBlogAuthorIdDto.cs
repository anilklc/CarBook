using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.Author
{
    public class GetAuthorByBlogAuthorIdDto
    {
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public string AuthorID { get; set; }
    }
}
