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
using static System.Net.Mime.MediaTypeNames;

namespace ComboBox_Manager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewItemTextBox.Text))
            {
                var newItem = new ComboBoxItem();

                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                var image = new System.Windows.Controls.Image
                {
                    Width = 30,
                    Height = 30,
                    Margin = new Thickness(5),
                    Source = string.IsNullOrWhiteSpace(ImagePathTextBox.Text)
                    ? new BitmapImage(new Uri("default-avatar.png", UriKind.Relative))
                    : new BitmapImage(new Uri(ImagePathTextBox.Text, UriKind.RelativeOrAbsolute))
                };
                stackPanel.Children.Add(image);

                var textBlock = new TextBlock
                {
                    Text = NewItemTextBox.Text,
                    Margin = new Thickness(5, 0, 0, 0),
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel.Children.Add(textBlock);

                newItem.Content = stackPanel;

                newItem.Background = GetSelectedColor();

                ItemComboBox.Items.Add(newItem);

                NewItemTextBox.Clear();
                ImagePathTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a name for the new item.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (ItemComboBox.SelectedItem != null)
            {
                ItemComboBox.Items.Remove(ItemComboBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private SolidColorBrush GetSelectedColor()
        {
            var selectedItem = ColorItemComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string selectedColor = selectedItem.Content.ToString();
                switch (selectedColor)
                {
                    case "Red": return new SolidColorBrush(Colors.Red);
                    case "Green": return new SolidColorBrush(Colors.Green);
                    case "Blue": return new SolidColorBrush(Colors.Blue);
                    case "Yellow": return new SolidColorBrush(Colors.Yellow);
                    case "Orange": return new SolidColorBrush(Colors.Orange);
                    case "Purple": return new SolidColorBrush(Colors.Purple);
                    case "Brown": return new SolidColorBrush(Colors.Brown);
                    case "Gray": return new SolidColorBrush(Colors.Gray);
                    case "Pink": return new SolidColorBrush(Colors.Pink);
                    case "Black": return new SolidColorBrush(Colors.Black);
                    default: return new SolidColorBrush(Colors.White);
                }
            }

            return new SolidColorBrush(Colors.White);
        }

        private void NewItemTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewItemTextBox.Text == "Enter item name")
            {
                NewItemTextBox.Text = "";
                NewItemTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void NewItemTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewItemTextBox.Text))
            {
                NewItemTextBox.Text = "Enter item name";
                NewItemTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void ImagePathTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ImagePathTextBox.Text == "Enter image path")
            {
                ImagePathTextBox.Text = "";
                ImagePathTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void ImagePathTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImagePathTextBox.Text))
            {
                ImagePathTextBox.Text = "Enter image path";
                ImagePathTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

    }
}

