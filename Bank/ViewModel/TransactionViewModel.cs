using Bank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel
{
    public class TransactionViewModel 
    {
        TransactionModel tm { get; set; }

        TransactionViewModel()
        {
            tm = new TransactionModel();
        }

        void ValidateTransaction()
        {
            tm.ValidateTransaction(tm);
        }
    }
}
