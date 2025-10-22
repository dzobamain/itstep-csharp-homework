using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProductManagement
{
    public partial class Form2 : Form
    {
        public Product Product { get; private set; }

        public Form2()
        {
            InitializeComponent();
            Product = new Product();
        }

        public Form2(Product product) : this()
        {
            txtName.Text = product.Name;
            txtCountry.Text = product.Country;
            txtPrice.Text = product.Price.ToString();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtCountry.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price format.");
                return;
            }

            Product.Name = txtName.Text;
            Product.Country = txtCountry.Text;
            Product.Price = price;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}