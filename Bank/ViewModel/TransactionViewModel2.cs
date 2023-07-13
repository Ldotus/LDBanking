using Bank.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;

namespace Bank.ViewModel
{
    /*ViewModels : The ViewModel prepares the data from the Model to be
    displayed in the View. For example, it retrieves the player's stats,
    items, and quest progress from the Model and provides them to the
    View for rendering.*/

    /*The ViewModel also handles user input and triggers actions in the
    Model based on that input.For instance, it receives the player's
    command to attack a monster, validates the action, and updates the
    Model accordingly.*/


    /*Additionally, the ViewModel notifies the View about any changes
    in the underlying data using mechanisms like data binding or
    event-driven communication. This enables the View to update its
    visuals in real-time based on the changes in the Model.*/

    public class TransactionViewModel2 : INotifyPropertyChanged
    {
        //TODO: add properties to view model to bind to the data needed in the view i.e. Textboxes etc
        //TODO: bind controls to ViewModel properties to XAML binding i.e. {Binding textBox1} 
        //TODO: implement commands: create command in viewmodel to be triggered when control is clicked
        public event PropertyChangedEventHandler? PropertyChanged;
        private TransactionService transactionService;
        private ObservableCollection<Transaction> _transactions;
        private string? _addAmountTextBox;
        private string? _placeTextBox;

        //property for Text box for Amount.
        public string? AddAmountTextBox
        {
            set
            {
                _addAmountTextBox = value;
                OnPropertyChanged(nameof(AddAmountTextBox));
            }
        }
        public string? PlaceTextBox
        {
            set
            {
                _placeTextBox = value;
                OnPropertyChanged(nameof(PlaceTextBox));
            }
        }
        public ObservableCollection<Transaction> Transactions
        {
            get 
            {  
                if (_transactions == null)
                {
                    _transactions = new ObservableCollection<Transaction>();

                }
                return _transactions;
            }

        }


        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public TransactionViewModel2()
        {
            _transactions = new ObservableCollection<Transaction>();
        }

        public void AddTransaction(Transaction transactionModel)
        {
            _transactions.Add(transactionModel);
        }
        public void RemoveTransaction(Transaction transactionModel)
        {
            _transactions.Remove(transactionModel);
        }
    }
}
