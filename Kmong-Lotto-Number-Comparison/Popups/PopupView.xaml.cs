using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Kmong_Lotto_Number_Comparison.Popups
{
    public partial class PopupView : UserControl
    {
        public PopupView()
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer();
            Stopwatch sw = new Stopwatch();
            dt.Interval = new System.TimeSpan(0, 0, 0, 0, 10);

            dt.Tick += (s, e) =>
            {
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    TimerDisplay.Text = $"{sw.Elapsed.Minutes} 분 {sw.Elapsed.Seconds} 초 {sw.Elapsed.Milliseconds}";
                }), DispatcherPriority.Background);

            };

            dt.Start();
            sw.Start();
        }
    }
}
