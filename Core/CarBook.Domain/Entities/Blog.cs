using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Blog : BaseEntity
    {
    
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorID { get; set; }
        public Author Author { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
