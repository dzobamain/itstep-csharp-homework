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

namespace Grid_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RemoveTextButton(object sender, RoutedEventArgs e)
        {
            TextBlock0_0.Visibility = Visibility.Collapsed;
            TextBlock0_1.Visibility = Visibility.Collapsed;

            TextBlock1_0.Visibility = Visibility.Collapsed;
            TextBlock1_1.Visibility = Visibility.Collapsed;
            TextBlock1_2.Visibility = Visibility.Collapsed;
            TextBlock1_3.Visibility = Visibility.Collapsed;

            TextBlock2_0.Visibility = Visibility.Collapsed;
            TextBlock2_1.Visibility = Visibility.Collapsed;
            TextBlock2_2.Visibility = Visibility.Collapsed;
            TextBlock2_3.Visibility = Visibility.Collapsed;

            TextBlock3_0.Visibility = Visibility.Collapsed;
            TextBlock3_1.Visibility = Visibility.Collapsed;
            TextBlock3_2.Visibility = Visibility.Collapsed;
            TextBlock3_3.Visibility = Visibility.Collapsed;
        }

        private void RestoreTextButton(object sender, RoutedEventArgs e)
        {
            TextBlock0_0.Visibility = Visibility.Visible;
            TextBlock0_1.Visibility = Visibility.Visible;

            TextBlock1_0.Visibility = Visibility.Visible;
            TextBlock1_1.Visibility = Visibility.Visible;
            TextBlock1_2.Visibility = Visibility.Visible;
            TextBlock1_3.Visibility = Visibility.Visible;

            TextBlock2_0.Visibility = Visibility.Visible;
            TextBlock2_1.Visibility = Visibility.Visible;
            TextBlock2_2.Visibility = Visibility.Visible;
            TextBlock2_3.Visibility = Visibility.Visible;

            TextBlock3_0.Visibility = Visibility.Visible;
            TextBlock3_1.Visibility = Visibility.Visible;
            TextBlock3_2.Visibility = Visibility.Visible;
            TextBlock3_3.Visibility = Visibility.Visible;
        }
    }
}
