﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    //Author: Abdulwahab Alansari
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupName { get; set; }
        public List<Product> Products { get; set; }
    }
}
