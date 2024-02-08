using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.DTOs
{
    public class BlogAndAuthorDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public string CategoryID { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
