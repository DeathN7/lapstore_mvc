using System;
using System.Collections.Generic;
using testmvc.Models;

namespace testmvc.ModelViews
{
    public class ProductHomeVM
    {
        public Category Category { get; set; }
        public List<Product> lsProducts { get; set; }
    }
}
