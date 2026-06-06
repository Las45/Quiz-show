using Quiz_show.src.Klassen;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow mw;
        Supabase.Client client;
        public Windows.Register register;

        public Login(MainWindow window, Supabase.Client client)
        {
            InitializeComponent();
            this.mw = window;
            this.client = client;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Height = 400;
            window.Width = 400;
        }

      

        private async void Weiter_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Logging.logger.Debug("Sign In with Password");
                await this.client.Auth.SignInWithPassword(email_login.Text, password_login.Password);
                Weiter_login.IsEnabled = false;
                StartLoginTransition();
            }
            catch
            {
                MessageBox.Show("Es gibt diesen User nicht oder das Passwort ist falsch");
            }
        }

        // KI: Claude
        // Prompt: How can I add a Zoom out and Zoom in Animation for my frames.
        // Anfang KI:
        private void StartLoginTransition()
        {
            DoubleAnimation shrinkX = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(550))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };
            DoubleAnimation shrinkY = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(550))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };
            DoubleAnimation fadeCard = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(350))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };

            shrinkY.Completed += ShrinkY_Completed;

            CardScale.BeginAnimation(ScaleTransform.ScaleXProperty, shrinkX);
            CardScale.BeginAnimation(ScaleTransform.ScaleYProperty, shrinkY);
            LoginCard.BeginAnimation(OpacityProperty, fadeCard);
        }

        private void ShrinkY_Completed(object sender, EventArgs e)
        {
            Phase2_Blackout();
        }

        private void Phase2_Blackout()
        {
            BlackoutOverlay.IsHitTestVisible = true;

            DoubleAnimation blackIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(500))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };
            blackIn.Completed += BlackIn_Completed;
            BlackoutOverlay.BeginAnimation(OpacityProperty, blackIn);
        }

        private void BlackIn_Completed(object sender, EventArgs e)
        {
            Phase3_Navigate();
        }

        private void Phase3_Navigate()
        {
            this.mw.Change_Frame_by_name("Home");
        }

        // Ende KI

        private void Password_fg_login_Click(object sender, RoutedEventArgs e)
        {
            Logging.logger.Debug("Password has been forgotten");
            mw.Change_Frame_by_name("Passwort_forgotten");
        }

        private void New_user_loin_Click(object sender, RoutedEventArgs e)
        {
            Logging.logger.Debug("A new User was Created");
            register = new Windows.Register(this.client);
            register.ShowDialog();
        }
    }
}
