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
    //Author: Abdulwahab Alansari
    public partial class AddProductToPackageForm : Form
    {
        public int PackageID { get; set; }

        //List of products and all suppliers associated with them
        List<ProductSupplier> productSuppliers;

        public AddProductToPackageForm()
        {
            InitializeComponent();
        }

        private void AddProductToPackageForm_Load(object sender, EventArgs e)
        {
            //Fill up productSuppliers with products that are not already part of the selected package 
            productSuppliers = Operations.GetProductSuppliers(PackageID);

            //Exit and show error message when the package already has all products
            if (productSuppliers.Count < 1) {
                MessageBox.Show("There are no products left to add", "No Products Available");
                this.Close();
                return;
            }

            //Populate cbProducts combobox with all products
            foreach (ProductSupplier ps in productSuppliers)
            {
                cbProducts.Items.Add(ps.product.ProdName);
            }
            //Select the first item in the combobox
            cbProducts.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int productId = productSuppliers[cbProducts.SelectedIndex].product.ProductId;
            int packageId = PackageID;
            int supplierId = productSuppliers[cbProducts.SelectedIndex].suppliers[cbSuppliers.SelectedIndex].SupplierId;
            Operations.AddProductToPackage(productId, supplierId, packageId);
            this.Close();
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear cbSuppliers combox items
            cbSuppliers.Items.Clear();

            //Populate cbSuppliers with suppliers' names
            foreach (Supplier sp in productSuppliers[cbProducts.SelectedIndex].suppliers)
            {
                cbSuppliers.Items.Add(sp.SupName);
            }

            //Select the first item in the combobox
            cbSuppliers.SelectedIndex = 0;
        }
    }
}
