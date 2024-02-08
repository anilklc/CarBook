using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Comment : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public Guid BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
