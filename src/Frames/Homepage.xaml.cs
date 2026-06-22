using OllamaSharp;
using Quiz_show.src.Klassen;
using Quiz_show.src.usercontrols.Icons;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        private OllamaApiClient _client;
        private bool ersterAufruf = true;

        public Homepage()   
        {
            InitializeComponent();
            Logging.logger.Debug("Homepage opened");
            Install_AI install_AI = new Install_AI();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Height = 1000;
            window.Width = 2000;
            Logging.logger.Debug("Homepage loaded");

            if (ersterAufruf)
            {
                DispatcherTimer delay = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(80) };
                delay.Tick += Delay_Tick;
                delay.Start();
            }
            else
            {
                ersterAufruf = false;
            }
        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            ersterAufruf = false;
            Logging.logger.Debug("Homepage initialization done");
        }

    }
}
