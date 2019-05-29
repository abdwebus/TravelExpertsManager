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
        private List<Package> packages;
        public PackagesForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Populate packages
            packages = Operations.GetPackages();

            //Populate Package Combobox control
            refreshPackageControl();

            //Select first item in the combobox
            cbPackages.SelectedIndex = 0;
        }

        private void cbPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbProducts.Items.Clear();
            foreach (Product product in packages[cbPackages.SelectedIndex].Products)
            {
                lbProducts.Items.Add(product.ProdName + "-" + product.Supplier.SupName);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            int selectedPackageIndex = cbPackages.SelectedIndex;
            AddProductToPackageForm frm = new AddProductToPackageForm();
            frm.PackageID = packages[cbPackages.SelectedIndex].PackageId;
            frm.ShowDialog();

            //Reload packages and refresh package and product controls
            packages = Operations.GetPackages();
            refreshPackageControl();
            cbPackages.SelectedIndex = selectedPackageIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPackageForm frm = new AddPackageForm();
            frm.ShowDialog();
        }

        /// <summary>
        /// Refresh Package Combobox control
        /// </summary>
        private void refreshPackageControl() {
            cbPackages.Items.Clear();
            foreach (Package package in packages)
            {
                cbPackages.Items.Add(package.PkgName);
            }
        }
    }
}
