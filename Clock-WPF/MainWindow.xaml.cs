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
using System.Windows.Threading;

namespace Clock
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            DrawClockNumbers();
            SetAllHandsToInitialPosition();
            DelayThenStart(1000);
        }


        private void SetAllHandsToInitialPosition()
        {
            SetHandAngle(SecondHand, 0, 200);
            SetHandAngle(MinuteHand, 0, 180);
            SetHandAngle(HourHand, 0, 120);
        }

        private async void DelayThenStart(int time)
        {
            await Task.Delay(time);
            StartClock();
        }

        private void DrawClockNumbers()
        {
            double radius = 250;
            double centerX = 250;
            double centerY = 250;

            for (int i = 1; i <= 12; i++)
            {
                double angle = (i - 3) * 30 * Math.PI / 180;
                double x = centerX + radius * 0.85 * Math.Cos(angle);
                double y = centerY + radius * 0.85 * Math.Sin(angle);

                TextBlock number = new TextBlock
                {
                    Text = i.ToString(),
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Black
                };

                Canvas.SetLeft(number, x - 10);
                Canvas.SetTop(number, y - 10);

                NumbersCanvas.Children.Add(number);
            }
        }

        private void StartClock()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateClock;
            timer.Start();
            UpdateClock(null, null);
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            double secAngle = now.Second * 6;
            double minAngle = now.Minute * 6 + now.Second * 0.1;
            double hourAngle = (now.Hour % 12) * 30 + now.Minute * 0.5;

            SetHandAngle(SecondHand, secAngle, 200);
            SetHandAngle(MinuteHand, minAngle, 180);
            SetHandAngle(HourHand, hourAngle, 120);
        }

        private void SetHandAngle(Line hand, double angleDeg, double length)
        {
            double angleRad = angleDeg * Math.PI / 180;
            double centerX = 250;
            double centerY = 250;

            double x = centerX + length * Math.Cos(angleRad - Math.PI / 2);
            double y = centerY + length * Math.Sin(angleRad - Math.PI / 2);

            hand.X2 = x;
            hand.Y2 = y;
        }
    }
}

