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
using System.Windows.Shapes;
using OllamaSharp;
using OllamaSharp.Models;

namespace Quiz_show.src.Windows
{
    /// <summary>
    /// Interaktionslogik für InstallModell.xaml
    /// </summary>
    public partial class InstallModell : Window
    {
        private OllamaApiClient client;
        public InstallModell(OllamaApiClient client)
        {
            InitializeComponent();
            this.client = client;
        }
        private async Task PullModel()
        {
            await foreach(PullModelResponse status in client.PullModelAsync("llama3.2:1b"))
            {
                int prozent = (int)((double)status.Completed / (double)status.Total * 100);
                if (status.Total > 0){
                    prozent_text_install.Text = $"{prozent}%";
                    Progress_bar_install.Value = prozent;
                }
                status_install_textblock.Text = $"Downloade llama:3.2:1b";
            }
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await PullModel();
        }
    }
}
