using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    //Author: Abdulwahab Alansari
    public class ProductSupplier
    {
        public Product product { get; set; }
        public List<Supplier> suppliers { get; set; }
    }
}
