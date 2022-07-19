using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank.Model
{
    public class ExpenditureModel
    {
        public int Id { get; }
        public string? Name { get;}
        public string Amount { get; }
        public TransactionModel? transaction { get; }
        public ExpenditureModel(TransactionModel trans)
        {
            Amount = trans.Amount;
            Name = trans.Name;
            Id = trans.Id;
        }
    }
}

