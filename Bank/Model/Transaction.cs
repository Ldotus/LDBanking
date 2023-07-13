using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank.Model
{
    public class Transaction
    {
        protected short UID;
        protected string? TransactionType;
        protected double Amount;
        protected DateTime DateTime;



        protected bool SuccessOrNot;

        public Transaction()
        {
        }

        public Transaction(short uid, string? transactionType, double amount, DateTime dateTime, bool successOrNot)
        {
            UID = uid;
            TransactionType = transactionType;
            Amount = amount;
            DateTime = dateTime;
            SuccessOrNot = successOrNot;

        }



    }
}
