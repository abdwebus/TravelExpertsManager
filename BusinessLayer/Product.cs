﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProdName { get; set; }
        public Supplier Supplier { get; set; }
    }
}