using Bank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bank.View
{
    /// <summary>
    /// Interaction logic for loggedIn2.xaml
    /// </summary>
    public partial class loggedIn2 : Window
    {
        protected virtual EventHandler IsCheckedEventHandler { get; set; }

        ObservableCollection<TransactionModel> _transactions;
        public loggedIn2()
        {
            InitializeComponent();
            _transactions = new ObservableCollection<TransactionModel>();

            createTransactions();

            Dg.ItemsSource = _transactions;

        }

        private void ListView_Checked(object sender, RoutedEventArgs e)
        {

        }
        void createTransactions()
        {
    

            int id = _transactions.Count;

            TransactionModel newT = new TransactionModel(id, "a place", 20.2m, DateTime.Now, "void");

           
            _transactions.Add(new TransactionModel(id, "Somewhere", 123.2m, DateTime.Now, "void"));
            _transactions.Add(newT);
            _transactions.Add(new TransactionModel(id, "Somewhere else", 12.2m, DateTime.Now.AddDays(-2), "El Void"));
        }

    }
}
