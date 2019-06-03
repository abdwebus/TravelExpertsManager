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
    public partial class ProductsForm : Form
    {
        List<Product> products = Operations.GetProducts();
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {   
            foreach (Product Prod in products)
            {
                prodCmBox.Items.Add(Prod.ProdName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (addTxtBox.Text == "")
            {
                MessageBox.Show("Enter a Value");
            }
            else
            {
                Operations.InsertProduct(addTxtBox.Text, 69);
                products = Operations.GetProducts();
                prodCmBox.Items.Clear();

                foreach (Product Prod in products)
                {
                    prodCmBox.Items.Add(Prod.ProdName);
                }

                addTxtBox.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void edtBtn_Click(object sender, EventArgs e)
        {
            UpdateProduct pf = new UpdateProduct();
            pf.Show();
        }
    }
}
