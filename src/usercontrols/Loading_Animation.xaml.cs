using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Quiz_show.src.usercontrols
{
    public partial class Loading_Animation : UserControl
    {
        private DispatcherTimer timer;
        private int count = 0;

        public Loading_Animation()
        {
            InitializeComponent();
            SetupAnimation();
        }

        private void SetupAnimation()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            rect1.Height = 25 + (15 * Math.Sin(count * 0.2));
            rect2.Height = 25 + (15 * Math.Cos(count * 0.2));
            rect3.Height = 25 + (15 * Math.Sin(count * 0.2));

            count++;
        }
    }
}