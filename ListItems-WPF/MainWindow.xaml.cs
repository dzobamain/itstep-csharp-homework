using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ListItems_WPF
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Item> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<Item>();
            ListItems.ItemsSource = Items;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Items.Add(new Item
            {
                Name = NameTextBox.Text,
                Model = ModelTextBox.Text,
                Price = PriceTextBox.Text,
                Description = DescriptionTextBox.Text
            });

            NameTextBox.Clear();
            ModelTextBox.Clear();
            PriceTextBox.Clear();
            DescriptionTextBox.Clear();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListItems.SelectedItem is Item selectedItem)
            {
                Items.Remove(selectedItem);
            }
        }

        private void ListItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListItems.SelectedItem is Item selectedItem)
            {
                NameTextBox.Text = selectedItem.Name;
                ModelTextBox.Text = selectedItem.Model;
                PriceTextBox.Text = selectedItem.Price;
                DescriptionTextBox.Text = selectedItem.Description;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}

