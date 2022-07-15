using System.ComponentModel;

namespace Bank.Model
{
    public class TransactionModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private double _amount;
        private string _validationMessage;

        public string ValidationMessage
        {
            get { return _validationMessage; }
            set { _validationMessage = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value + 1; INotifyPropertyChanged("Id"); }
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; INotifyPropertyChanged("Name"); }
        }
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; INotifyPropertyChanged("Amount"); }
        }

        public TransactionModel(string name, double amount)
        {
            Id += 1;
            this.Name = name;
            this.Amount = amount;
        }

        public TransactionModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void ValidateTransaction()
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
            }
        }
        public void addTransction()
        {

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
