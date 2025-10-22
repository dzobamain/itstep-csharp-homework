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

namespace Convertor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Background = WindowBackround("pack://application:,,,/fotos/windowBackround.jpg");
            ComboBoxCountry.SelectionChanged += ComboBoxCountry_SelectionChanged;
            UpdateUnitComboBoxes("Not selected");
        }

        private ImageBrush WindowBackround(string path_foto)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(path_foto));
            brush.Stretch = Stretch.UniformToFill;

            return brush;
        }

        private void ComboBoxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = (ComboBoxCountry.SelectedItem as ComboBoxItem)?.Content.ToString();
            UpdateUnitComboBoxes(selected);
        }

        private void UpdateUnitComboBoxes(string country)
        {
            ComboBoxUnitOfMeasurement.Items.Clear();
            ComboBoxToUnitOfMeasurement.Items.Clear();

            List<string> usUnits = new List<string> { "Inch", "Foot", "Yard", "Mile" };
            List<string> euUnits = new List<string> { "Millimeter", "Centimeter", "Meter", "Kilometer" };

            var allUnits = new List<string>();
            allUnits.AddRange(usUnits);
            allUnits.AddRange(euUnits);
            foreach (var unit in allUnits)
            {
                ComboBoxToUnitOfMeasurement.Items.Add(unit);
            }

            switch (country)
            {
                case "USA":
                    foreach (var unit in usUnits)
                    {
                        ComboBoxUnitOfMeasurement.Items.Add(unit);
                    }
                    break;

                case "Other":
                    foreach (var unit in euUnits)
                    {
                        ComboBoxUnitOfMeasurement.Items.Add(unit);
                    }
                    break;

                case "Not selected":
                default:
                    foreach (var unit in allUnits)
                    {
                        ComboBoxUnitOfMeasurement.Items.Add(unit);
                    }
                    break;
            }

            if (ComboBoxUnitOfMeasurement.Items.Count > 0)
                ComboBoxUnitOfMeasurement.SelectedIndex = 0;

            if (ComboBoxToUnitOfMeasurement.Items.Count > 0)
                ComboBoxToUnitOfMeasurement.SelectedIndex = 0;
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            string fromUnit = ComboBoxUnitOfMeasurement.SelectedItem?.ToString();
            string toUnit = ComboBoxToUnitOfMeasurement.SelectedItem?.ToString();
            string valueText = TextBoxValue.Text;

            if (double.TryParse(valueText, out double value))
            {
                double valueInMeters = ConvertToMeters(value, fromUnit);
                double convertedValue = ConvertFromMeters(valueInMeters, toUnit);

                TextBoxToValue.Text = convertedValue.ToString("F4");
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric value.");
            }
        }

        private double ConvertToMeters(double value, string fromUnit)
        {
            var toMeters = new Dictionary<string, double>
            {
                { "Millimeter", 0.001 },
                { "Centimeter", 0.01 },
                { "Meter", 1.0 },
                { "Kilometer", 1000.0 },
                { "Inch", 0.0254 },
                { "Foot", 0.3048 },
                { "Yard", 0.9144 },
                { "Mile", 1609.34 }
            };

            return toMeters.ContainsKey(fromUnit) ? value * toMeters[fromUnit] : value;
        }

        private double ConvertFromMeters(double valueInMeters, string toUnit)
        {
            var fromMeters = new Dictionary<string, double>
            {
                { "Millimeter", 1000.0 },
                { "Centimeter", 100.0 },
                { "Meter", 1.0 },
                { "Kilometer", 0.001 },
                { "Inch", 39.3701 },
                { "Foot", 3.28084 },
                { "Yard", 1.09361 },
                { "Mile", 0.000621371 }
            };

            return fromMeters.ContainsKey(toUnit) ? valueInMeters * fromMeters[toUnit] : valueInMeters;
        }
    }
}
