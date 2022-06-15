using System.Windows;
using System.Windows.Controls;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool firstTime;

        public MainWindow()
        {
            InitializeComponent();
            firstTime = true;
        }

        private void Tb1_GotFocus(object sender, RoutedEventArgs e)
        {

            if (Tb1.Text == "Enter Account Number")
            {
                Tb1.Text = null;
            }
            else
            {

                Tb1.Text = Tb1.Text;


            }


        }
        private void Tb1_LostFocus(object sender, RoutedEventArgs e)
        {


            if (Tb1.Text.Length > 0)
            {
                Tb1.Text = Tb1.Text;
            }
            else
            {
                Tb1.Text = "Enter Account Number";
            }


        }
        private void tb2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb2.Text == "Pin")
            {
                tb2.Text = null;
            }
            else
            {
                tb2.Text = tb2.Text;
                firstTime = false;

            }

        }
        private void tb2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb2.Text.Length > 0)
            {

            }
            else
            {
                tb2.Text = "Enter Pin";
            }
        }



        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string first4, second4, third4, fourth4;

            if (firstTime)
            {

            }
            if (tb2.Text.Length == 4)
            {
                
                tb2.AppendText("-");
                tb2.Select(tb2.Text.Length, 0);
            }
            if (tb2.Text.Length == 9)
            {
               
                tb2.AppendText("-");
                tb2.Select(tb2.Text.Length, 0);
            }
            if(tb2.Text.Length == 14)
            {
                tb2.AppendText("-");
                tb2.Select(tb2.Text.Length, 0);
            }
       
              
        }
    }
}
