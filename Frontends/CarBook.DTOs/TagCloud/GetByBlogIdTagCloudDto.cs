using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TagCloud
{
    public class GetByBlogIdTagCloudDto
    {
        public string TagCloudID { get; set; }
        public string Title { get; set; }
        public string BlogID { get; set; }
    }
}
