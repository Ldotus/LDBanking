using Bank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bank
{
    /// <summary>
    /// Interaction logic for LoggedIn.xaml
    /// </summary>
    ///
    public partial class LoggedIn : Window
    {
        readonly ObservableCollection<TransactionModel> TransactionObservableCollection;
        private ObservableCollection<TransactionModel> CommitmentObservableCollection;
        TransactionModel t;
        UserModel user;
        private List<TransactionModel> _commitmentList;
        public LoggedIn()
        {
            InitializeComponent();
            t = new TransactionModel();
            user = new UserModel();
            TransactionObservableCollection = new ObservableCollection<TransactionModel>();
            CommitmentObservableCollection = new ObservableCollection<TransactionModel>();

            
            _commitmentList = new List<TransactionModel>();

            DataContext = t;

        }

        private void deleteTransactionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TransactionObservableCollection.Count > 0)
            {
                if (transactionList.SelectedIndex != -1)
                {
                    TransactionObservableCollection.RemoveAt(transactionList.SelectedIndex);
                    
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
        private void CheckFuturePurchase()
        {
            if (DateTimeBox.SelectedDate >= DateTime.Now)
            {
                MessageBox.Show("The Date you have provided is in the future.", "Future Purchase");
            }
        }
        private void addTransaction(object sender, RoutedEventArgs e)
        {
            //checks Name checkbox for text
            if (AddTransactionPlaceTxtb.Text.Length >= 4)
            {
                decimal TransactionAmount = Convert.ToDecimal(AddAmountTxtb.Text);

                //checks the amount is more than 0.01
                //add as constant /**/
                if (TransactionAmount >= 0.01m)
                {

                    /*checks a date has been specified before
                    class instantion occurs */

                    if (DateTimeBox.SelectedDate != null)
                    {
                        CheckFuturePurchase();

                        //uses the input of the textboxes & date
                        if (CategoryComboBox.SelectedIndex == -1)
                        {
                            t.TransactionType = "Unexpected";
                        }
                        else
                        {
                            t.TransactionType = CategoryComboBox.SelectedItem.ToString();
                        }
                        string place = AddTransactionPlaceTxtb.Text;
                        string amount = AddAmountTxtb.Text;

                        /* 
                         */
                        t.Amount = ChangeToDecimal(amount);
                        int id = TransactionObservableCollection.Count;

                        t.Dt = DateTimeBox.SelectedDate.Value.Date;


                        //  string? tt = CategoryComboBox.SelectedItem.ToString();

                        TransactionModel newT = new TransactionModel(id, place, t.Amount, t.Dt, t.TransactionType);

                        if (CommitmentCheckBox.IsChecked == true)
                        {
                            CommitmentObservableCollection.Add(newT);

                            commitmentsListView.ItemsSource = CommitmentObservableCollection;
                           // expendetureList.ItemsSource = CommitmentObservableCollection;
                            _commitmentList.Add(newT);
                            UpdateCommitmentBalance();
                        }
                        else
                        {
                            TransactionObservableCollection.Add(newT);
                            transactionList.ItemsSource = TransactionObservableCollection;
                            UpdateTransactionalBalance();
                           // expendetureList.ItemsSource = TransactionObservableCollection;
                        }
                        var output = new ObservableCollection<TransactionModel>(CommitmentObservableCollection.Concat(TransactionObservableCollection));

                        expendetureList.ItemsSource = output;
                    }

                }
                else
                {
                    MessageBox.Show("Ensure all Fiels are Filled in", "Something went wrong");
                }

            }
        }
        private void UpdateTransactionalBalance()
        {
          if (TransactionObservableCollection.Count > 0)
            {
                decimal sumOfTransactions = 0;
                foreach (var transaction in TransactionObservableCollection)
                {
                    string transactionalAmount = transaction.Amount.ToString();
                    decimal decAmount = ChangeToDecimal(transactionalAmount);

                    sumOfTransactions += decAmount;

                }
                decimal balance = ChangeToDecimal(txtBalance.Text);
                balance -= sumOfTransactions;
                if (balance < 0)
                {
                    txtAfterTransactionalBalance.Foreground = Brushes.Red;
                }
                else
                {
                    txtAfterTransactionalBalance.Foreground = Brushes.GreenYellow;
                }
                txtAfterTransactionalBalance.Text = balance.ToString();
            }
        }
        private void UpdateCommitmentBalance()
        {


            if (CommitmentObservableCollection.Count > 0)
            {
                decimal sumOfCommitments = 0;

                foreach (var commitment in CommitmentObservableCollection)
                {
                    string commitedAmount = commitment.Amount.ToString();

                    decimal decAmount = ChangeToDecimal(commitedAmount);

                    sumOfCommitments += decAmount;


                }
                decimal balance = ChangeToDecimal(txtBalance.Text);

                balance -= sumOfCommitments;
                if (balance < 0)
                {

                    txtAfterCommitmentsBalance.Foreground = Brushes.Red;
                }
                else
                {
                    txtAfterCommitmentsBalance.Foreground = Brushes.GreenYellow;
                }

                txtAfterCommitmentsBalance.Text = Convert.ToString(balance);
            }
        }
      /*  private void addTransactionBtn_Click(object sender, RoutedEventArgs e)
        {

            t.Place = this.AddTransactionPlaceTxtb.Text;

            string str = this.AddAmountTxtb.Text;

            t.Amount = ChangeToDecimal(str);


            string? selectedDate = DateTimeBox.SelectedDate.Value.Date.ToShortDateString();


            int id = TransactionObservableCollection.Count;


            TransactionModel newT = new TransactionModel(id, t.Place, t.Amount, selectedDate, "TT");

            string? val = t.ValidateTransaction(newT);

            if (newT.Success == true)
            {

                newT.ValidationMessage = val;

                if (newT.ValidationMessage == "Just Right")
                {
                    if (CommitmentCheckBox.IsChecked ?? true)
                    {
                        CommitmentObservableCollection.Add(newT);

                        commitmentsListView.ItemsSource = CommitmentObservableCollection;

                    }
                    else
                    {
                        oc.Add(newT);
                        transactionList.ItemsSource = oc;
                    }

                }


            }
            else if (newT.Success == false)
            {

                MessageBox.Show("Transaction Failed, Ensure all fields are filled " + val, "Something Went Wrong");


            }



        }
      */
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

                UpdateCommitmentBalance();
                UpdateTransactionalBalance();

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

                    UpdateCommitmentBalance();
                    UpdateTransactionalBalance();
                }
            }
        }

        private void ReorganiseExpendetureWeeklyClick(object sender, RoutedEventArgs e)
        {
            
            var lastWeekCommitments = CommitmentObservableCollection.Where(t => t.Dt > DateTime.Now.AddDays(-7)).ToList();
            var lastWeekTransactions = TransactionObservableCollection.Where(t => t.Dt > DateTime.Now.AddDays(-7)).ToList();

            var total = new ObservableCollection<TransactionModel>(lastWeekTransactions.Concat(lastWeekCommitments));
            expendetureList.ItemsSource = lastWeekTransactions;
        }

        private void ReorganiseExpendetureMonthlyClick(object sender, RoutedEventArgs e)
        {

            var lastMonthCommitment = CommitmentObservableCollection.Where(t => t.Dt > DateTime.Now.AddMonths(-1)).ToList();
            var lastMonthTransactions = TransactionObservableCollection.Where(t => t.Dt > DateTime.Now.AddMonths(-1)).ToList();

            var total = new ObservableCollection<TransactionModel>(lastMonthCommitment.Concat(lastMonthTransactions));
            expendetureList.ItemsSource = total;
        }

        private void ReorganiseExpendetureYearlyClick(object sender, RoutedEventArgs e)
        {

            var lastYearCommitment = CommitmentObservableCollection.Where(t => t.Dt > DateTime.Now.AddMonths(-1)).ToList();
            var lastYearTransactions = TransactionObservableCollection.Where(t => t.Dt > DateTime.Now.AddMonths(-1)).ToList();

            var total = new ObservableCollection<TransactionModel>(lastYearCommitment.Concat(lastYearTransactions));
            expendetureList.ItemsSource = lastYearTransactions;
        }
    }
}
