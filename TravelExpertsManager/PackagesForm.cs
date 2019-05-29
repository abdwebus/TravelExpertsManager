using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace TravelExpertsManager
{
    public partial class PackagesForm : Form
    {
        private List<Package> packages = Operations.GetPackages();
        public PackagesForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Package package in packages)
            {
                cbPackages.Items.Add(package.PkgName);
            }
        }

        private void cbPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbProducts.Items.Clear();
            foreach (Product product in packages[cbPackages.SelectedIndex].Products)
            {
                lbProducts.Items.Add(product.ProdName + "-" + product.Supplier.SupName);
            }
        }
    }
}
