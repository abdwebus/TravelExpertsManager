using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sqlclient;

namespace TravelExpertsManager
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {

        }
        public static Supplies GetSupplies(int ID)
        {
            SqlConnection Connection = TravelExperts.GetConnection();
            Suppliers p = new Suppliers();
            try
            {
                string sql = "SELECT SupplierId, SupName FROM Supplies WHERE ID"
            }
        }
    }
}
