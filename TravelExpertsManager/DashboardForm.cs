using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsManager
{
    //Author: Abdulwahab Alansari
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PackagesForm frm = new PackagesForm();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductsForm frm = new ProductsForm();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Suppliers frm = new Suppliers();
            frm.ShowDialog();
        }
    }
}
