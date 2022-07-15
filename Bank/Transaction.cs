using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Model;


namespace Bank
{
    public class Transaction 
    {
        protected short UID;
        protected string? TransactionType;
        protected double Amount;
        protected DateTime DateTime;

        protected UserModel? User;

        protected bool SuccessOrNot;

        public Transaction()
        {
        }

        public Transaction(short uid, string? transactionType, double amount, DateTime dateTime, bool successOrNot)
        {
           this.UID = uid;
            this.TransactionType = transactionType;
            this.Amount = amount;
            this.DateTime = dateTime;
            this.SuccessOrNot = successOrNot;

        }

        

    }
}
