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
            if (tb2.Text == "Enter Pin")
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
                tb2.Text = tb2.Text;
            }
            else
            {
                tb2.Text = "Enter Pin";
            }
        }



        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
        

            if (Tb1.Text.Length %5  == 4)
            {
                if (Tb1.Text.Length <= 16)
                {
                    Tb1.AppendText("-");

                    Tb1.Select(Tb1.Text.Length, Tb1.Text.Length) ;
                

                }
              
            }
          
       
              
        }
        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
