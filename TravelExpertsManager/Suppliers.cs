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
{   //this page was done by Mustafa Warsama
    public partial class Suppliers : Form
    {   // list of Suppliers are mention in the begiin so all operations be able to access this list
        List<Supplier> suppliers = Operations.GetSuppliers();
       

        public Suppliers()
        {
            //made input field not visible so user select which field they want to use
            InitializeComponent();
            panel5.Visible = false;
            panel6.Visible = false;
            panel4.Visible = false;
            panel8.Visible = false;
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
          // for each loop allows you to get all the informations required from the list 
            foreach (Supplier info in suppliers)
            {
                //listBox1.Items.Add(info.SupplierId + "-" + info.SupName);
                
                dataGridView1.DataSource = Operations.GetSuppliers();
            }
            // this code makes the datagridview column size to resize so that all the data to show up as page loads 
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

        }


       

        private void Add_Click_1(object sender, EventArgs e)
        {
            // this parts allows the operations of adding suppliers in to the data accord
            int SupplierID = 0;
            //int id = Convert.ToInt32(txtSupplierID.Text);
           if (AddSupName.Text != "")
            {                
                Operations.InsertSupplier(SupplierID, AddSupName.Text);
                MessageBox.Show("Record Inserted Successfully");
                dataGridView1.DataSource = Operations.GetSuppliers();
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            else
            {
                MessageBox.Show("Please Fill Supplier ID, and Name!");
            }
           
        }


        private void Edit_Click_1(object sender, EventArgs e)
        {
            // this parts allows the operations of adding suppliers in to the data accord

            //int id = Convert.ToInt32(txtSupplierID.Text);
            if (txtSupplierID.Text != "" && txtSupName.Text != "")
            {
                Operations.UpdateSupplier(Convert.ToInt32(txtSupplierID.Text), txtSupName.Text);
                MessageBox.Show("Record Inserted Successfully");
                dataGridView1.DataSource = Operations.GetSuppliers();
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            else
            {
                MessageBox.Show("Please make sure Supplier ID, and Supplier Name are Filled!");
            }

        }

        private void txtSupplierID_Validated(object sender, EventArgs e)
        {
            // this part makes validition for the supplierID txtbox, only nummbers are is allowed   

            int parsedValue;
            if (!int.TryParse(txtSupplierID.Text, out parsedValue))
            {
                MessageBox.Show("SupplierID Field Must be Filled with SupplierID Number");
                return;
            }

        }

        private void txtSupName_TextChanged(object sender, EventArgs e)
        {
            // this part makes validition for the suppliername txtbox, only string is allowed  

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSupName.Text, "^[a-zA-Z ]"))
                {
                    MessageBox.Show("This Textbox Accepts Only Alphabetical Characters");
               
                }
            
        }

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            //this code displays the selected field 
            panel5.Visible = true;
            panel6.Visible = true;
            panel4.Visible = false;
            panel8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this code displays the selected field 
            panel5.Visible = false;
            panel6.Visible = false;
            panel4.Visible = true;
            panel8.Visible = true;
        }

        private void AddSupName_TextChanged(object sender, EventArgs e)
        {// this part makes validition for the suppliername txtbox, only string is allowed  

            if (!System.Text.RegularExpressions.Regex.IsMatch(AddSupName.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This Textbox Accepts Only Alphabetical Characters");
               
            }

        }

       
    }
}
