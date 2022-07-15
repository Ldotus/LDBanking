using Bank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Bank
{
    /// <summary>
    /// Interaction logic for LoggedIn.xaml
    /// </summary>
    ///
    public partial class LoggedIn : Window
    {
        TransactionModel tModel;
        ObservableCollection<TransactionModel> oc;
        public LoggedIn()
        {
            InitializeComponent();
            TransactionModel t = new TransactionModel();
            oc = new ObservableCollection<TransactionModel>()

            {
              new TransactionModel()
              {
                  Name = "Turkish Kebab",
                  Amount = 20.59,
                  Id = t.Id,
              },
               new TransactionModel()
              {
                  Name = "German Kebab",
                  Amount = 40.50,
                  Id = t.Id,
              },
                new TransactionModel()
              {
                  Name = "Swedish Kebab",
                  Amount = 1.23,
                  Id = t.Id,
              }
            };
            this.transactionList.ItemsSource = oc;

        }

        public void addToListView(List<Transaction> t)
        {


        }

        private void addTransactionBtn_Click(object sender, RoutedEventArgs e)
         {
            string place = this.AddTransactionPlaceTxtb.Text;

            string amount = this.AddAmountTxtb.Text;



            var amounT = double.Parse(amount);

            TransactionModel newT = new TransactionModel(place, amounT);

            oc.Add(newT);

            this.transactionList.ItemsSource = oc;

            Console.WriteLine(oc.Count);

        }
        private void tb2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.AddTransactionPlaceTxtb.Text == "Enter Place")
            {
                AddTransactionPlaceTxtb.Text = null;
            }
            else
            {
                AddTransactionPlaceTxtb.Text = AddTransactionPlaceTxtb.Text;
            }
        }
    }
}
