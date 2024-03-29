﻿using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{ //author,blog cqrs oluştur ama blog ekstradan son 3 gösteren get işleminide göster author bazalarak dieğrinde bran almıştık onun gibi
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
