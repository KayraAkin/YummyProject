﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class Category
    {
        public int CatetgoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}