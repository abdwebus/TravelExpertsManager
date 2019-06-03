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
            string name = txtName.Text;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            string description = txtDescription.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            decimal commision = Convert.ToDecimal(txtCommision.Text);
            bool result = Operations.InsertPackage(name, startDate, endDate, description, price, commision);
            MessageBox.Show(result.ToString());
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "") {
                errName.SetError(txtName, "Invalid name");
                e.Cancel = true;
            }
        }
    }
}
