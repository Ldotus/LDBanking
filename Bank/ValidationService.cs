using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
    class ValidationService
    {
        public string? ValidateTransaction(TransactionModel transaction)
        {
            if (transaction.Place != null)
            {
                if (transaction.Place.Trim().Length <= 1 || transaction.Amount <= 0)
                {
                    transaction.Success = false;
                    return "Not Long Enough";
                }
                else if (transaction.Place.Trim().Length >= 20)
                {
                    transaction.Success = false;
                    return "This is too long";
                }
                else
                {
                    transaction.Success = true;
                    return "Just Right";
                }
            }
            return null;
        }
    }
}
