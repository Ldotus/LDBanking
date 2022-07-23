using System;
using System.ComponentModel;

namespace Bank.Model
{
    public class TransactionModel : INotifyPropertyChanged
    {
        private int _id;
        private string? _name;
        private decimal _amount;
        private string? _validationMessage;


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



        public string? Name
        {
            get { return _name; }
            set { _name = value; INotifyPropertyChanged(nameof(Name)); }
        }
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; INotifyPropertyChanged(nameof(Amount)); }
        }

        public TransactionModel(int id, string name, decimal amount)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;

        }

        public TransactionModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string? ValidateTransaction(TransactionModel transaction)
        {
            if (Name != null)
            {
                if (Name.Trim().Length <= 1)
                {
                    ValidationMessage = "This is not long enough";
                }
                else if (Name.Trim().Length >= 20)
                {
                    ValidationMessage = "This is too long";
                }
                else
                {
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
