﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductSupplier
    {
        public Product product { get; set; }
        public List<Supplier> suppliers { get; set; }
    }
}
