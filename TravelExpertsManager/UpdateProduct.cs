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
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void UpdateProduct__Load(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = Operations.GetProduct( 1);
            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = bs;
            //dataGridView1.Refresh();
            var products = Operations.ShowProducts();
            dataGridView1.DataSource = products;
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operations.UpdateProduct(Convert.ToInt32(idBox.Text), updBox.Text);
            var products = Operations.ShowProducts();
            dataGridView1.DataSource = products;
            //dataGridView1.Update();
            //dataGridView1.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
