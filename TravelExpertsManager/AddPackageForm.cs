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
    public partial class AddPackageForm : Form
    {
        public AddPackageForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!controlsAreValid()) {
                return;
            }
            string name = txtName.Text;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            string description = txtDescription.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            decimal commision = Convert.ToDecimal(txtCommision.Text);
            bool result = Operations.InsertPackage(name, startDate, endDate, description, price, commision);
            if (result)
            {
                MessageBox.Show("Package added successfully!", "Package Added");
                this.Close();
            } else {
                MessageBox.Show("Something went wrong, try again later", "Unknown Error");
            }            
        }

        private bool controlsAreValid() {
            errName.Clear();
            if (txtName.Text == "")
            {
                errName.SetError(txtName, "Name is required!");
            }
            else if (dtpStartDate.Value >= dtpEndDate.Value) {
                errName.SetError(dtpEndDate, "End date must be later than start date");
            }
            else if (txtDescription.Text == "")
            {
                errName.SetError(txtDescription, "Discription is required!");
            }
            else if (txtPrice.Text == "" || !decimal.TryParse(txtPrice.Text, out decimal p))
            {
                errName.SetError(txtPrice, "Price is required and should be in the correct format");
            }
            else if (txtCommision.Text == "" || !decimal.TryParse(txtCommision.Text, out decimal c))
            {
                errName.SetError(txtCommision, "Commission is required and should be in the correct format");
            }
            else if (Convert.ToDecimal(txtCommision.Text) > Convert.ToDecimal(txtPrice.Text)) {
                errName.SetError(txtCommision, "Commission can't be greater than the base price");
                txtCommision.Focus();
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
