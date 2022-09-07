using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Bank.Model
{
    public class TransactionModel : UserModel, INotifyPropertyChanged
    {
        private int _id;
        private string? _place;
        private decimal _amount;
        private string? _validationMessage;
        private bool? _Success;
        private DateTime? _dt;
        private string? _transactionType;
        private UserModel _um;
        
       
        private ObservableCollection<string>? _comboContent { get; set; }

        public TransactionModel(int id, string? place, decimal amount, DateTime? dt,string? transactionType)
        {
            Id = id;
            Place = place;
            Amount = amount;
            Dt = dt;
            TransactionType = transactionType;

            
        }

        public TransactionModel()
        {
            ComboContent = new ObservableCollection<string>
            {
                "Food",
                "Luxury",
                "Bills",
                "Unexpected"
            };
            
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public string? TransactionType
        {
            get { return _transactionType; }
            set { _transactionType = value; INotifyPropertyChanged(nameof(TransactionType)); }
        }
        public ObservableCollection<string>? ComboContent
        {
            get { return _comboContent; }
            set {   _comboContent = value; INotifyPropertyChanged(nameof(ComboContent)); }
        }
        public string? ValidationMessage
        {
            get { return _validationMessage; }
            set { _validationMessage = value; INotifyPropertyChanged(nameof(ValidationMessage)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; INotifyPropertyChanged(nameof(Id)); }
        }

        public bool? Success
        {
            get { return _Success; }
            set { _Success = value; INotifyPropertyChanged(nameof(Success)); }
        }

        public string? Place
        {
            get { return _place; }
            set { _place = value; INotifyPropertyChanged(nameof(Place)); }
        }
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; INotifyPropertyChanged(nameof(Amount)); }
        }

        public DateTime? Dt
        {
            get { return _dt; }
            set { _dt = value; INotifyPropertyChanged(nameof(Dt)); }
        }

        public UserModel User
        {
            get { return _um; }
            set { _um = value; INotifyPropertyChanged(nameof(User)); }
        }


        public string? ValidateTransaction(TransactionModel transaction)
        {
            if (Place != null)
            {
                if (Place.Trim().Length <= 1 || Amount <= 0)
                {
                    transaction.Success = false;
                    ValidationMessage = "Not Long Enough";
                }
                else if (Place.Trim().Length >= 20)
                {
                    transaction.Success = false;
                    ValidationMessage = "This is too long";
                }
                else
                {
                    transaction.Success = true;
                    ValidationMessage = "Just Right";
                }
            }
            return ValidationMessage;
        }

        private void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }


    }
}
