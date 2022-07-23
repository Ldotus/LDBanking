using Bank.Model;
using Bank.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Bank
{
    /// <summary>
    /// Interaction logic for LoggedIn.xaml
    /// </summary>
    ///
    public partial class LoggedIn : Window
    {
        readonly ObservableCollection<TransactionModel> oc;
        readonly ObservableCollection<TransactionModel> oc2;
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
            if (stringAmount != String.Empty)
            {
                decimal amount = Convert.ToDecimal(stringAmount);
                stringAmount = amount.ToString("F");
                decimal finalAmount = Convert.ToDecimal(stringAmount);
                return finalAmount;
            }
            else
            {
                return 0;
            }


        }

        private void addTransactionBtn_Click(object sender, RoutedEventArgs e)
        {
            t.Name = this.AddTransactionPlaceTxtb.Text;

            string str = this.AddAmountTxtb.Text;

            t.Amount = ChangeToDecimal(str);


            int id = oc.Count;


            
            TransactionModel newT = new TransactionModel(id, t.Name, t.Amount);

            var transaction = t.ValidateTransaction(newT);

            if (transaction != null)

                if (CommitmentCheckBox.IsChecked ?? true)
            {

             

                {
                    if (transaction == "Just Right")
                    {
                        oc2.Add(newT);
                        ErrorMessage.Text = newT.ValidationMessage;
                        this.commitmentsListView.ItemsSource = oc2;
                    }

                    else if (transaction == "This is not long enough")
                    {

                        ErrorMessage.Text = newT.ValidationMessage;

                        PopUpMessage pum = new PopUpMessage();

                        pum.Content = newT.ValidationMessage;

                        pum.Show();


                    }
                    
                }

            }
            else
            {
                oc.Add(newT);

                this.transactionList.ItemsSource = oc;
            }
          

        }

        private void tb2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;

            if (textbox.Text.Length >= 3)
            {
                textbox.Text = null;

            }
            else
            {
                textbox.Text = textbox.Text;
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
