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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        private bool ersterAufruf = true;

        public Homepage()
        {
            InitializeComponent();
        }

        
        public void SetReturnMode()
        {
            ersterAufruf = false;

            ContentCanvas.Opacity = 1;
            ContentScale.ScaleX = 1;
            ContentScale.ScaleY = 1;
            BlackoutOverlay.Opacity = 1;
            BlackoutOverlay.IsHitTestVisible = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Height = 1000;
            window.Width = 2000;

            if (ersterAufruf)
            {
                DispatcherTimer delay = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(80) };
                delay.Tick += Delay_Tick;
                delay.Start();
            }
            else
            {
                StartReturnAnimation();
                ersterAufruf = false;
            }
        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            ersterAufruf = false;
            StartRevealAnimation();
        }

        // KI: Claude
        // Prompt: How can i make a zoom out and zoom in animation for my login / home frame:
        // Anfang: KI
        private void StartRevealAnimation()
        {
            DoubleAnimation blackOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(600))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            blackOut.Completed += BlackOut_Completed;
            BlackoutOverlay.BeginAnimation(OpacityProperty, blackOut);

            DoubleAnimation expandX = new DoubleAnimation(0.3, 1.0, TimeSpan.FromMilliseconds(700))
            {
                BeginTime = TimeSpan.FromMilliseconds(150),
                EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.4 }
            };
            DoubleAnimation expandY = new DoubleAnimation(0.3, 1.0, TimeSpan.FromMilliseconds(700))
            {
                BeginTime = TimeSpan.FromMilliseconds(150),
                EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.4 }
            };
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(400))
            {
                BeginTime = TimeSpan.FromMilliseconds(150)
            };

            ContentScale.BeginAnimation(ScaleTransform.ScaleXProperty, expandX);
            ContentScale.BeginAnimation(ScaleTransform.ScaleYProperty, expandY);
            ContentCanvas.BeginAnimation(OpacityProperty, fadeIn);
        }

        private void StartReturnAnimation()
        {
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(400))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            fadeOut.Completed += BlackOut_Completed;
            BlackoutOverlay.BeginAnimation(OpacityProperty, fadeOut);
        }

        private void BlackOut_Completed(object sender, EventArgs e)
        {
            BlackoutOverlay.IsHitTestVisible = false;
        }

        // Ende KI:
    }
}
