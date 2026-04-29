using System.Windows;

namespace Quiz_show
{
    public partial class TranslatorWindow : Window
    {
        TranslatorClass translator = new TranslatorClass();



        Dictionary<string, string> deToEn = new Dictionary<string, string>();


        Dictionary<string, string> enToDe = new Dictionary<string, string>();

        public TranslatorWindow()
        {
            InitializeComponent();

            foreach (var pair in deToEn)


                enToDe[pair.Value] = pair.Key;

            LanguageBox.SelectedIndex = 0;
        }

        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text;

            if (LanguageBox.SelectedIndex == 0)
            {
                OutputText.Text = translator.TranslateDeToEn(input);
            }


            else

                OutputText.Text = translator.TranslateEnToDe(input);

        }
    }
}