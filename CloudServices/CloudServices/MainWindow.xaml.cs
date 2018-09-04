using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace CloudServices
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private short _numberOfLicences = 0;
        private short[] _licencesPerService = new short[7];
        private short _numberOfServices = 0;


        public short NumberOfLicences
        {
            get => _numberOfLicences;

            set
            {
                if (value >= 1)
                {
                    _licencesPerService[_numberOfServices] = value;
                    _numberOfServices++;
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GetFocus(object sender, RoutedEventArgs e)
        {
            TextBox quantityBox = sender as TextBox;
            if (quantityBox.Text == "0")
            {
                quantityBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox quantityBox = sender as TextBox;

            if (quantityBox.Text == "")
            {
                quantityBox.Text = "0";
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!isNumber(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool isNumber(string text)
        {
            int output;
            return int.TryParse(text, out output);
        }
    }
}
