    using Quiz_show.src.Klassen;
    using Quiz_show.usercontrols.Icons;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
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
    using System.Drawing;

    namespace Quiz_show.Frames
    {
        /// <summary>
        /// Interaktionslogik für Shoppage.xaml
        /// </summary>
        public partial class Shoppage : Page
        {
            public Shoppage()
            {
                InitializeComponent();
                UpdateUI();
            }



            private void UpdateUI()
            {
                RectOriginalButton.Fill = new SolidColorBrush(Shop.GetButtonColor());
                RectRotButton.Fill = new SolidColorBrush(Shop.GetButtonColor());
                RectGoldButton.Fill = new SolidColorBrush(Shop.GetButtonColor());

                RectOriginalBackground.Fill = new SolidColorBrush(Shop.GetButtonColor());
                RectGrünBackground.Fill = new SolidColorBrush(Shop.GetButtonColor());
                RectSilberBackground.Fill = new SolidColorBrush(Shop.GetButtonColor());

                PathExit.Fill = new SolidColorBrush(Shop.GetButtonColor());

                MoneyLabel.Content = Shop.Money + " Coins";
            }



            private void PathExit_MouseUp(object sender, MouseButtonEventArgs e)
            {
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                UpdateUI();
                main.Change_Frame_by_name("Home");

            }

            private void PathExit_MouseLeave(object sender, MouseEventArgs e)
            {
                PathExit.Opacity = 1;
            }

            private void PathExit_MouseEnter(object sender, MouseEventArgs e)
            {
                PathExit.Opacity = 0.7;
            }

            private void RectOriginalButton_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Shop.Purchase(ShopItems.OriginalButton);
                UpdateUI();
            }

            private void RectRotButton_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Shop.Purchase(ShopItems.RotButton);

                UpdateUI();
            }

            private void RectGoldButton_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Shop.Purchase(ShopItems.GoldButton);
                UpdateUI();
            }

            private void RectOriginalBackground_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Shop.Purchase(ShopItems.OriginalBackground);
                UpdateUI();
            }

            private void Page_Loaded(object sender, RoutedEventArgs e)
            {

            UpdateUI();
            }
            private void RectGrünBackground_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Shop.Purchase(ShopItems.GrünBackground);
                UpdateUI();
            }

            private void RectSilberBackground_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Shop.Purchase(ShopItems.SilberBackground);
                UpdateUI();
            }












        }
    }
