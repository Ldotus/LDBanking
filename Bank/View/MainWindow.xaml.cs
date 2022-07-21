using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("C:\\Users\\libro\\source\\repos\\Bank\\Bank\\mula.jpg"));




        }

        //EVENT HANDLER; when Tb1 gets focus checks 
        //Removes placeholder text if expression is false
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
        // EVENT HANDLER; when PIN Textbox loses focuses, checks the length of the text
        // creates placeholder text if empty other wise stores in value

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
        //EVENT HANDLER; when Tb2 gets focus checks text
        //
        private void tb2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb2.Text == "Enter Pin")
            {
                tb2.Text = null;
            }
            else
            {
                tb2.Text = tb2.Text;
              

            }

        }
        // EVENT HANDLER; when PIN Textbox loses focuses, checks the length of the text
        // creates placeholder text if empty other wise stores in value
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
        //Code for textchanged event on textbox
        // as tb length increases after being appended
        // checks if text length mod 5 is equal to 4

            if (Tb1.Text.Length %5  == 4)
            {
                if (Tb1.Text.Length <= 16)
                {
                    Tb1.AppendText("-");

                    Tb1.Select(Tb1.Text.Length, Tb1.Text.Length);               

                }
              
            }
          
       
              
        }
        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            LoggedIn li = new LoggedIn();


            li.ShowDialog();

          
            
        }
    }
}
