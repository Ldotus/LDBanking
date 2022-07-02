using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
  
    public class UserModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AmountColour { get; set; }
        public string? EmailAddress { get; set; }

        public string IsMarried { get; set; }
        public DateOnly? DoB { get; set; }
        public double? Balance { get; set; }
        public double? CommitedAmount { get; set; }

        public UserModel()
        {

        }

    }
}
