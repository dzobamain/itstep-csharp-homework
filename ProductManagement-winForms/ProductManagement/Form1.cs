using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class Form1 : Form
    {
        private List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                products.Add(form2.Product);
                UpdateProductList();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedIndex >= 0)
            {
                Form2 form2 = new Form2(products[listBoxProducts.SelectedIndex]);
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    products[listBoxProducts.SelectedIndex] = form2.Product;
                    UpdateProductList();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedIndex >= 0)
            {
                products.RemoveAt(listBoxProducts.SelectedIndex);
                UpdateProductList();
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            products.Clear();
            UpdateProductList();
        }

        private void UpdateProductList()
        {
            listBoxProducts.Items.Clear();
            foreach (var product in products)
            {
                listBoxProducts.Items.Add($"{product.Name} - {product.Country} - {product.Price:C}");
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
    }
}

