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
            }else
            {
                Tb1.Text = "Enter Account Number";
            }


        }
        private void tb2_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tb2.Text == "Enter Pin")
            {
                tb2.Text = null;
            }
            else
            {
                tb2.Text = tb2.Text;
               
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

       
    }
}
