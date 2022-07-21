using System;
using System.ComponentModel;

namespace Bank.Model
{

    public class UserModel : INotifyPropertyChanged
    {
        private string? _firstName;
        private string? _lastName;
        private string? _amountColour;
        private string? _emailAddress;

        private string? _isMarried;
        private DateOnly? _doB;
        private decimal _balance;
        private double _commitedAmount;
        private double _expenditure;




        public UserModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void ValidateUser()
        {

        }
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                INotifyPropertyChanged(nameof(Balance));
            }
        }
        public double CommitedAmount
        {
            get { return _commitedAmount; }
            set
            {
                _commitedAmount = value;
                INotifyPropertyChanged(nameof(CommitedAmount));
            }
        }
        public double Expendeture
        {
            get { return _expenditure; }
            set
            {
                _expenditure = value;
                INotifyPropertyChanged(nameof(Expendeture));
            }
        }
    }
}
