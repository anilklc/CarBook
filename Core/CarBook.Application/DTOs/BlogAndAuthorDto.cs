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
        public string Description { get; set; }
        public Guid AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
