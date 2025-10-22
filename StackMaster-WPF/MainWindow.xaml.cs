using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StackMaster
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Головний контейнер Grid
            Grid mainGrid = new Grid
            {
                Margin = new Thickness(25)
            };

            // Визначення колонок
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1) }); // Для пунктирної лінії
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1) }); // Для пунктирної лінії
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Перша колонка (0 block)
            StackPanel stackPanel1 = CreateStackPanel(Orientation.Vertical, Brushes.White);
            stackPanel1.Children.Add(CreateTextBlock("StackPanel 1"));
            stackPanel1.Children.Add(CreateButton("Button 1", new Thickness(10, 15, 10, 0)));
            stackPanel1.Children.Add(CreateButton("Button 2", new Thickness(10, 15, 10, 0)));
            stackPanel1.Children.Add(CreateButton("Button 3", new Thickness(10, 15, 10, 0)));
            Grid.SetColumn(stackPanel1, 0);
            mainGrid.Children.Add(stackPanel1);

            // Пунктирна лінія між 0 block і 1 block
            Line dashedLine1 = CreateDashedLine();
            Grid.SetColumn(dashedLine1, 1);
            mainGrid.Children.Add(dashedLine1);

            // Друга колонка (1 block)
            StackPanel stackPanel2 = CreateStackPanel(Orientation.Vertical, Brushes.White);
            stackPanel2.Children.Add(CreateTextBlock("StackPanel 2"));
            stackPanel2.Children.Add(CreateButton("Button 4", new Thickness(10, 0, 10, 0)));
            stackPanel2.Children.Add(CreateButton("Button 5", new Thickness(10, 0, 10, 0)));
            stackPanel2.Children.Add(CreateButton("Button 6", new Thickness(10, 0, 10, 0)));
            Grid.SetColumn(stackPanel2, 2);
            mainGrid.Children.Add(stackPanel2);

            // Пунктирна лінія між 1 block і 2 block
            Line dashedLine2 = CreateDashedLine();
            Grid.SetColumn(dashedLine2, 3);
            mainGrid.Children.Add(dashedLine2);

            // Третя колонка (2 block)
            StackPanel stackPanel3 = CreateStackPanel(Orientation.Vertical, Brushes.White);
            stackPanel3.Children.Add(CreateTextBlock("StackPanel 3"));
            stackPanel3.Children.Add(CreateButton("Button 7", new Thickness(10, 15, 10, 0)));
            stackPanel3.Children.Add(CreateButton("Button 8", new Thickness(10, 15, 10, 0)));
            stackPanel3.Children.Add(CreateButton("Button 9", new Thickness(10, 15, 10, 0)));
            Grid.SetColumn(stackPanel3, 4);
            mainGrid.Children.Add(stackPanel3);

            // Встановлюємо Grid як вміст вікна
            this.Content = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(50),
                Background = Brushes.SkyBlue,
                Child = mainGrid
            };
        }

        // Метод для створення StackPanel
        private StackPanel CreateStackPanel(Orientation orientation, Brush background)
        {
            return new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Orientation = orientation,
                Background = background
            };
        }

        // Метод для створення TextBlock
        private TextBlock CreateTextBlock(string text)
        {
            return new TextBlock
            {
                Text = text,
                Margin = new Thickness(5),
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 18
            };
        }

        // Метод для створення Button
        private Button CreateButton(string content, Thickness margin)
        {
            return new Button
            {
                Content = content,
                Margin = margin,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
        }

        // Метод для створення пунктирної лінії
        private Line CreateDashedLine()
        {
            return new Line
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                StrokeDashArray = new DoubleCollection { 4, 2 }, // Пунктир
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = 1,
                Stretch = Stretch.Fill
            };
        }
    }
}
