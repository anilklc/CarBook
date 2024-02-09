using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.Blog
{
    public class ResultLastThreeBlogDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public string CategoryID { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
