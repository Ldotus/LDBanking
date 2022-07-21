using Bank.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Bank
{
    /// <summary>
    /// Interaction logic for LoggedIn.xaml
    /// </summary>
    ///
    public partial class LoggedIn : Window
    {

        ObservableCollection<TransactionModel> oc;
        ObservableCollection<TransactionModel> oc2;
        TransactionModel t;
        UserModel user;
        public LoggedIn()
        {
            InitializeComponent();
            t = new TransactionModel();
            user = new UserModel();
            oc = new ObservableCollection<TransactionModel>();
            oc2 = new ObservableCollection<TransactionModel>();
            this.DataContext = oc;
           
        }

        private void deleteTransactionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (oc.Count > 0)
            {
                if (transactionList.SelectedIndex != -1)
                {
                    oc.RemoveAt(transactionList.SelectedIndex);
                }

            }
        }

        public decimal ChangeToDecimal(string stringAmount)
        {
            decimal amount = Convert.ToDecimal(stringAmount);
            stringAmount = amount.ToString("F");
            decimal finalAmount = Convert.ToDecimal(stringAmount);

            return finalAmount;
        }

        private void addTransactionBtn_Click(object sender, RoutedEventArgs e)
        {
            t.Name = this.AddTransactionPlaceTxtb.Text;

            string str = this.AddAmountTxtb.Text;

            t.Amount = ChangeToDecimal(str);

        
            int id = oc.Count;
            


            TransactionModel newT = new TransactionModel(id, t.Name, t.Amount);


            if (CommitmentCheckBox.IsChecked ?? true)
            {
                oc2.Add(newT);
                newT.ValidateTransaction();
                ErrorMessage.Content = newT.ValidationMessage.ToString();
                this.commitmentsListView.ItemsSource = oc2;
            }
            else
            {
                oc.Add(newT);

                this.transactionList.ItemsSource = oc;
            }





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
        private void depositBtnClick(object sender, RoutedEventArgs e)
        {
            string str = this.transactionBox.Text;
            
            if (str.Equals("all"))
            {
                user.Balance = decimal.MaxValue;
                this.txtBalance.Text = user.Balance.ToString();
            }
            else
            {
                decimal amount = ChangeToDecimal(str);

                user.Balance += amount;

                this.txtBalance.Text = user.Balance.ToString();

            }

        }
        private void withdrawBtnClick(object sender, RoutedEventArgs e)
        {
            string str = this.transactionBox.Text;
            if (!string.IsNullOrEmpty(str))
            {


                if (str.Equals("all"))
                {
                    user.Balance = 0;
                    this.txtBalance.Text = user.Balance.ToString();


                }
                else
                {
                    decimal amount = ChangeToDecimal(str);

                    user.Balance -= amount;

                    this.txtBalance.Text = user.Balance.ToString();
                }
            }
        }
    }
}
