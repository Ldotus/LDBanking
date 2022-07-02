using Bank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel
{
    public class UserViewModel
    {
        private UserModel um = new UserModel();

        public string _firstNameTxt 
        {
           get { return um.FirstName; }
           set { um.FirstName = value; }
        }
        public string _lastNameTxt
        {
            get { return um.LastName; }
            set { um.LastName = value; }
        }
        public string _EmailTxt
        {
            get { return um.EmailAddress; }
            set { um.EmailAddress = value; }
        }
        public string _amountColour
        {
            get
            {
                if (um.Balance > 2000)
                {
                    return "Blue";
                }
                else if (um.Balance > 1000)
                {
                    return "Yellow";
                }
                return "Red";
            }

        }
        public bool? IsMarried
        {
            get
            {
                if (um.IsMarried == "Married")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
